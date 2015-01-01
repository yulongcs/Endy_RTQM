using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WebEzi.Base.DefinedData;
using WebEzi.Core.Domain.Base.Model;
using WebEzi.Core.Domain.Base.ModelFactory;
using WebEzi.Core.Exception.Domain;
using WebEzi.Data;


namespace WebEzi.Core.Domain.Base.Repository
{
    /// <summary>
    /// The base of the repository
    /// </summary>
    public abstract class RepositoryBase<T, TU, D, DE> : IRepository<T>
        where T : IAggregateRoot
        where DE : System.Data.Linq.DataContext
        where D : DataContextBase<DE> 
    {
        #region IRepository<T> Members

        void IRepository.Insert(IAggregateRoot model)
        {
            this.Insert((T)model);
        }

        void IRepository.Update(IAggregateRoot model)
        {
           this.Update((T)model);
        }

        void IRepository.Delete(WEKey key)
        {
            this.Delete(key);
        }

        public virtual void Insert(T model)
        {
            if (model == null)
            {
                throw new RepositoryException("Model can't be null when insert model.");
            }

            model.CheckStructure();

            using (var dataContext = this.InitDataContext())
            {
                var newEntityKey = InsertModel(model, dataContext.EntityContext);

                this.ExecuteAfterInsert(model, newEntityKey);
            }
        }

        public virtual void Update(T model)
        {
            if (model == null)
            {
                throw new RepositoryException("Model can't be null when update model.");
            }

            model.CheckStructure();

            using (var dataContext = this.InitDataContext())
            {
                var entity = GetEntityBy(model.Key, dataContext.EntityContext);

                UpdateModel(model, entity, dataContext.EntityContext);
            }
        }

        public virtual void Delete(WEKey key)
        {
            if (key.IsNullOrEmpty())
            {
                throw new RepositoryException("The Key of a Model can't be null or empty when deleting a model.");
            }

            using (var dataContext = this.InitDataContext())
            {
                var entity = GetEntityBy(key, dataContext.EntityContext);

                DeleteModel(key, entity, dataContext.EntityContext);
            }
        }

        protected abstract D InitDataContext();

        protected abstract TU GetEntityBy(WEKey key, DE entityContext);

        protected abstract TU InsertModel(T model, DE entityContext);

        protected abstract void ExecuteAfterInsert(T model, TU newEntity);

        protected abstract void UpdateModel(T model, TU entity, DE entityContext);

        protected abstract void DeleteModel(WEKey key, TU entity, DE entityContext);

        #endregion

        /// <summary>
        /// Set model key when insert
        /// </summary>
        protected void SetModelKeyAfterInsert(EntityModelBase model, WEKey key)
        {
            model.Key = key;
        }

        protected IList<EntityModelBase> GetDeletedEntityModelCollection(T model)
        {
            return model.DeletedEntityModelCollection;
        }

        #region Build Domain

        protected TT BuildModelFactory<TT>() where TT : ModelFactoryBase
        {
            return DomainFactory.GetInstance().GetModelFactory<TT>();
        }

        #endregion
    }
}
