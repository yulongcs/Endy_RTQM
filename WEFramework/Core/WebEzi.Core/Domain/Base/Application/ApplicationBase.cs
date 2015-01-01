using System.Data;
using System.Data.Common;
using WebEzi.Base.DefinedData;
using WebEzi.Core.Domain.Base.Model;
using WebEzi.Core.Domain.Base.ModelFactory;
using WebEzi.Core.Domain.Base.Repository;


namespace WebEzi.Core.Domain.Base.Application
{
    /// <summary>
    /// The base of the application
    /// </summary>
    public abstract class ApplicationBase<T, D> : IApplication<T>
        where T : IAggregateRoot
        where D: IRepository<T>
    {
        #region IApplication Members

        IAggregateRoot IApplication.GetByKey(WEKey key)
        {
            return this.GetByKey(key);
        }

        #endregion

        public abstract T GetByKey(WEKey key);

        #region Build Domain

        protected TU BuildModelFactory<TU>() where TU : ModelFactoryBase
        {
            return DomainFactory.GetInstance().GetModelFactory<TU>();
        }

        protected D BuildRepository()
        {
            return DomainFactory.GetInstance().GetRepository<D>();
        }

        protected TU BuildApplication<TU>() where TU : IApplication
        {
            return DomainFactory.GetInstance().GetApplication<TU>();
        }

        #endregion
    }
}
