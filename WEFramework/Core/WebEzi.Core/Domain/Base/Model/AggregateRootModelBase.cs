using System.Collections.Generic;
using WebEzi.Base.DefinedData;
using WebEzi.Core.Domain.Base.Repository;

namespace WebEzi.Core.Domain.Base.Model
{
    public abstract class AggregateRootModelBase : EntityModelBase, IAggregateRoot
    {
        protected AggregateRootModelBase(WEKey key):base(key)
        {
        }

        #region IAggregateRoot 

        IList<EntityModelBase> IAggregateRoot.DeletedEntityModelCollection 
        {
            get
            {
                return this.DeletedEntityModelCollection;
            }
        }

        private List<EntityModelBase> _deletedEntityModelCollection;
        internal protected IList<EntityModelBase> DeletedEntityModelCollection
        {
            get
            {
                if (_deletedEntityModelCollection == null)
                {
                    _deletedEntityModelCollection = new List<EntityModelBase>();
                }

                return _deletedEntityModelCollection;
            }
        }

        #endregion
    }
}
