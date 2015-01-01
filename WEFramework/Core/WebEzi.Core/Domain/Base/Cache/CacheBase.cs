using System;
using System.Web;
using System.Web.Caching;


namespace WebEzi.Core.Domain.Base.Cache
{
    public abstract class CacheBase
    {
        protected abstract string ConnectionString { get; }

        protected abstract string DateBase { get; }

        protected abstract string Key { get; }

        protected abstract string[] DependencyTables { get; }

        protected abstract DateTime AbsoluteExpiration { get; }

        protected abstract TimeSpan SlidingExpiration { get; }

        protected abstract object ReadData();

        public virtual T GetCache<T>()
        {
            object data = HttpRuntime.Cache[this.Key];

            if (data == null)
            {
                data = ReadData();

                AttachCache(this.Key, data);
            }

            return (T)data;
        }

        public virtual void Clear()
        {
            HttpRuntime.Cache.Remove(this.Key);
        }

        protected void AttachCache(string key, object data)
        {
            AggregateCacheDependency dependency = null;
            if (this.DependencyTables != null && this.DependencyTables.Length > 0)
            {
                dependency = new AggregateCacheDependency();

                foreach (var table in this.DependencyTables)
                {
                    CacheNotification.GetInstance(ConnectionString).EnableTableForNotifications(table);

                    dependency.Add(new SqlCacheDependency(DateBase, table));
                }
            }

            HttpRuntime.Cache.Insert(key, data, dependency, this.AbsoluteExpiration, this.SlidingExpiration, CacheItemPriority.High, null);
        }
    }
}