using System.Data;
using WebEzi.Base.DefinedData;
using WebEzi.Core.Domain.Base.Application;
using WebEzi.Core.Domain.Base.Model;
using WebEzi.Core.Domain.Base.ModelFactory;
using WebEzi.Core.Domain.Base.Repository;

namespace WebEzi.Core.Domain.Base.Service
{
    /// <summary>
    /// The base of the service
    /// </summary>
    public abstract class ServiceBase
    {
        #region Build Domain

        protected T BuildModelFactory<T>() where T : ModelFactoryBase
        {
            return DomainFactory.GetInstance().GetModelFactory<T>();
        }

        protected T BuildApplication<T>() where T : IApplication
        {
            return DomainFactory.GetInstance().GetApplication<T>();
        }

        protected T BuildService<T>() where T : ServiceBase
        {
            return DomainFactory.GetInstance().GetService<T>();
        }

        #endregion
    }
}
