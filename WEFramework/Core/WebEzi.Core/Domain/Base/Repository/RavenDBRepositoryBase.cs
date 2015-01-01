using System.Collections.Generic;
using WebEzi.Base.DefinedData;
using WebEzi.Core.Domain.Base.Model;
using WebEzi.Core.Domain.Base.ModelFactory;
using WebEzi.Core.Exception.Domain;
using WebEzi.Data.RavenDB;

namespace WebEzi.Core.Domain.Base.Repository
{
    public abstract class RavenDbRepositoryBase<T,TU,D> : IRepository<T> 
        where T : IAggregateRoot
        where D : WEDocumentStore
        where TU : new()
    {
        #region IRepository<T> Members

        void IRepository.Insert(IAggregateRoot model)
        {
            Insert((T)model);
        }

        void IRepository.Update(IAggregateRoot model)
        {
            Update((T)model);
        }

        void IRepository.Delete(WEKey key)
        {
            Delete(key);
        }

        public virtual void Insert(T model)
        {
            if (model == null)
            {
                throw new RepositoryException("Model can't be null when insert model.");
            }

            model.CheckStructure();

            using (var documentStore = this.InitDocumentStore())
            {
                var newEntityKey = InsertModel(model, documentStore);

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

            using (var documentStore = this.InitDocumentStore())
            {
                var entity = GetEntityBy(model.Key, documentStore);
                if (entity == null)
                {
                    entity=new TU();
                }
                UpdateModel(model, entity, documentStore);
            }
        }

        public virtual void Delete(WEKey key)
        {
            if (key.IsNull())
            {
                throw new RepositoryException("Model can't be null when delete model.");
            }
            using (var documentStore = this.InitDocumentStore())
            {
                var entity = GetEntityBy(key, documentStore);

                DeleteModel(key, entity, documentStore);
            }
        }


        #endregion

        protected abstract TU GetEntityBy(WEKey key, D documentStore);

        protected abstract TU InsertModel(T model, D documentStore);

        protected abstract void ExecuteAfterInsert(T model, TU data);

        protected abstract void UpdateModel(T model, TU entity, D documentStore);

        protected abstract void DeleteModel(WEKey key, TU entity, D documentStore);

        protected abstract D InitDocumentStore();


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
