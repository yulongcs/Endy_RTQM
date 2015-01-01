using System;

namespace Lgsoft.SF.Domain
{
    /// <summary>
    /// 实体对象的基类。
    /// </summary>
    public class Entity
    {
        private int? _requestedHashCode;
        private Guid _id;

        /// <summary>
        /// 获取实体对象的持久化标识。
        /// </summary>
        public virtual Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnIdChanged();
            }
        }

        /// <summary>
        /// 当持久化标识发生变化时执行。
        /// </summary>
        protected virtual void OnIdChanged()
        {
            
        }

        /// <summary>
        /// 确定实体是否为临时实体对象（当前还没设置持久化标识）。
        /// </summary>
        /// <returns>是临时实体对象返回true，否则返回false。</returns>
        public bool IsTransient()
        {
            return Id == Guid.Empty;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (Entity)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            return item.Id == Id;
        }

        public override int GetHashCode()
        {
// ReSharper disable NonReadonlyFieldInGetHashCode
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }
// ReSharper disable BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
// ReSharper restore BaseObjectGetHashCodeCallInGetHashCode
// ReSharper restore NonReadonlyFieldInGetHashCode
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return Equals(right, null);
            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
