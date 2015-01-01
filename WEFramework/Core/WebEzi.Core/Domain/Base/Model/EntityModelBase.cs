using WebEzi.Base.DefinedData;

namespace WebEzi.Core.Domain.Base.Model
{
    public abstract class EntityModelBase : ModelBase
    {
        protected EntityModelBase(WEKey key)
        {
            //Please Notice: this place the code just deal with the Null Key excluding Empty Key, 
            //because ths model is allowed have a empty key during creating period. 
            if(key.IsNull())
            {
                throw  new System.Exception("Key must have a value.");
            }

            this.Key = key;
        }

        #region IAggregateRoot Members

        public WEKey Key { get; internal set; }

        public bool IsExist
        {
            get { return !this.Key.IsNullOrEmpty(); }
        }

        #endregion
    }
}
