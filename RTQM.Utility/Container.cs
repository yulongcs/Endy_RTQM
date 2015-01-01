using Lgsoft.RTQM.Application.BaseInfoModule.DTOAdapters;
using Lgsoft.RTQM.Application.BaseInfoModule.Services;
using Lgsoft.RTQM.Application.DisqualificationReportModule.DTOAdapters;
using Lgsoft.RTQM.Application.DisqualificationReportModule.Services;
using Lgsoft.RTQM.Application.FileModule.DTOAdapters;
using Lgsoft.RTQM.Application.FileModule.Services;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOAdapters;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.Services;
using Lgsoft.RTQM.Application.SecurityModule.DTOAdapters;
using Lgsoft.RTQM.Application.SecurityModule.Services;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.MaterialAgg;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg;
using Lgsoft.RTQM.Domain.DisqualificationReportModule.Aggregates.ReportAgg;
using Lgsoft.RTQM.Domain.FileModule.Aggregates.FileAgg;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.OrderLineAgg;
using Lgsoft.RTQM.Domain.RawMaterialQulityModule.Aggregates.PurchaseOrderAgg;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.RoleAgg;
using Lgsoft.RTQM.Domain.SecurityModule.Aggregates.UserAgg;
using Lgsoft.RTQM.Domain.SecurityModule.Services;
using Lgsoft.RTQM.Infrastructure.CrossCutting.NetFramework.Logging;
using Lgsoft.RTQM.Infrastructure.CrossCutting.NetFramework.Validator;
using Lgsoft.RTQM.Infrastructure.Data.BaseInfoModule.Repositories;
using Lgsoft.RTQM.Infrastructure.Data.DisqualificationReportModule.Repositories;
using Lgsoft.RTQM.Infrastructure.Data.FileModule.Repositories;
using Lgsoft.RTQM.Infrastructure.Data.RawMaterialQulityModule.Repositories;
using Lgsoft.RTQM.Infrastructure.Data.SecurityModule.Repositories;
using Lgsoft.RTQM.Infrastructure.Data.UnitOfWork;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;
using Lgsoft.SF.Infrastructure.CrossCutting.Logging;
using Lgsoft.SF.Infrastructure.CrossCutting.Validator;
using Microsoft.Practices.Unity;

namespace Lgsoft.RTQM.Utility
{
    public class Container
    {
        #region Properties

        static IUnityContainer _currentContainer;

        /// <summary>
        /// Get the current configured container
        /// </summary>
        /// <returns>Configured container</returns>
        public static IUnityContainer Current
        {
            get
            {
                return _currentContainer;
            }
        }

        #endregion

        #region Constructor

        static Container()
        {
            ConfigureContainer();

            ConfigureFactories();
        }

        #endregion

        #region Methods

        static void ConfigureContainer()
        {
            /*
             * Add here the code configuration or the call to configure the container 
             * using the application configuration file
             */

            _currentContainer = new UnityContainer();


            //-> Unit of Work and repositories
            _currentContainer.RegisterType<IRTQMUnitOfWork, RTQMUnitOfWork>(new PerResolveLifetimeManager());

            _currentContainer.RegisterType<IMaterialRepository, MaterialRepository>();
            _currentContainer.RegisterType<ISupplierRepository, SupplierRepository>();
            _currentContainer.RegisterType<IPurchaseOrderRepository, PurchaseOrderRepository>();
            _currentContainer.RegisterType<IOrderLineRepository, OrderLineRepository>();
            _currentContainer.RegisterType<IDisqualificationReportRepository, DisqualificationReportRepository>();
            _currentContainer.RegisterType<IFileRepository, FileRepository>();
            _currentContainer.RegisterType<IUserRepository, UserRepository>();
            _currentContainer.RegisterType<IRoleRepository, RoleRepository>();

            //-> Adapters
            _currentContainer.RegisterType<ITypeAdapter, TypeAdapter>();
            _currentContainer.RegisterType<RegisterTypesMap, BaseInfoModuleRegisterTypesMap>("baseinfomodule");
            _currentContainer.RegisterType<RegisterTypesMap, RawMaterialQulityModuleRegisterTypesMap>(
                "rawmaterialqulitymodule");
            _currentContainer.RegisterType<RegisterTypesMap, DisqualificationReportModuleRegisterTypesMap>(
                "disqualificationreportmodule");
            _currentContainer.RegisterType<RegisterTypesMap, FileModuleRegisterTypesMap>("filemodule");
            _currentContainer.RegisterType<RegisterTypesMap, SecurityModuleRegisterTypesMap>("securitymodule");

            //-> Domain Services
            _currentContainer.RegisterType<IUserRoleService, UserRoleService>();

            //-> Application services
            _currentContainer.RegisterType<IMaterialAppService, MaterialAppService>();
            _currentContainer.RegisterType<ISupplierAppService, SupplierAppService>();
            _currentContainer.RegisterType<IPurchaseOrderAppService, PurchaseOrderAppService>();
            _currentContainer.RegisterType<IDisqualificationReportAppService, DisqualificationReportAppService>();
            _currentContainer.RegisterType<IFileAppService, FileAppService>();
            _currentContainer.RegisterType<IUserAppService, UserAppService>();
            _currentContainer.RegisterType<IRoleAppService, RoleAppService>();

            //-> Distributed Services
        }


        static void ConfigureFactories()
        {
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
        }

        #endregion
    }
}
