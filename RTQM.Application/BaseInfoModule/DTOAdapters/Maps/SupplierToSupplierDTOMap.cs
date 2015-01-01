using AutoMapper;
using Lgsoft.RTQM.Application.BaseInfoModule.DTOs;
using Lgsoft.RTQM.Domain.BaseInfoModule.Aggregates.SupplierAgg;
using Lgsoft.SF.Infrastructure.CrossCutting.Adapters;

namespace Lgsoft.RTQM.Application.BaseInfoModule.DTOAdapters.Maps
{
    class SupplierToSupplierDTOMap : TypeMapConfigurationBase<Supplier, SupplierDTO>
    {
        #region Overrides of TypeMapConfigurationBase<Supplier,SupplierDTO>

        protected override void BeforeMap(ref Supplier source)
        {
            Mapper.CreateMap<Supplier, SupplierDTO>();
        }

        protected override void AfterMap(ref SupplierDTO target, params object[] moreSources)
        {
            
        }

        protected override SupplierDTO Map(Supplier source)
        {
            return Mapper.Map<Supplier, SupplierDTO>(source);
        }

        #endregion
    }
}
