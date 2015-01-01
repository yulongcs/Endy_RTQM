using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace WebEzi.Data
{
    public abstract class DataContextBase<T> : IDisposable
        where T : System.Data.Linq.DataContext
    {
        private const string EntityContextString = "EntityContext";
        private const string LockerString = "Locker";

        #region Entity Context

        private int? EntityContextLocker 
        {
            get
            {
                if (HttpContext.Current.Items["Locker"] != null)
                {
                    return (int) HttpContext.Current.Items["Locker"];
                }
                else
                {
                    return null;
                }
            }
        }

        [ThreadStatic]
        private static T _context;
        private T _webContext;

        public T EntityContext
        {
            get
            {
                // If web request
                if (HttpContext.Current != null)
                {
                    if (_webContext == null)
                    {
                        if (HttpContext.Current.Items[EntityContextString] == null)
                        {
                            _webContext = this.InitEntityContext();

                            HttpContext.Current.Items[EntityContextString] = _webContext;
                            HttpContext.Current.Items[LockerString] = this.GetHashCode();
                        }
                        else
                        {
                            _webContext = (T)HttpContext.Current.Items[EntityContextString];
                        }
                    }

                    return _webContext;
                }
                else // If winfrom or mutiple thread request
                {
                    return _context ?? (_context = this.InitEntityContext());
                }
            }
        }

        protected abstract T InitEntityContext();

        #endregion

        #region Transaction

        public void BeginTransaction()
        {
            var entityContext = this.EntityContext;
            var locker = this.EntityContextLocker;

            if (locker == this.GetHashCode() && entityContext.Transaction == null)
            {
                entityContext.Connection.Open();
                entityContext.Transaction = entityContext.Connection.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {
            var entityContext = this.EntityContext;
            var locker = this.EntityContextLocker;

            if (locker == this.GetHashCode() && entityContext != null)
            {
                entityContext.Transaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            var entityContext = this.EntityContext;
            var locker = this.EntityContextLocker;

            if (locker == this.GetHashCode() && entityContext.Transaction != null)
            {
                entityContext.Transaction.Rollback();
            }
        }

        #endregion

        public void Dispose()
        {
            var entityContext = this.EntityContext;
            var locker = this.EntityContextLocker;

            if (locker == this.GetHashCode())
            {
                if (entityContext.Connection != null)
                {
                    entityContext.Connection.Close();
                    entityContext.Connection.Dispose();
                }
                if (entityContext.Transaction != null)
                {
                    entityContext.Transaction.Dispose();
                    entityContext.Transaction = null;
                }

                entityContext.Dispose();

                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Items[EntityContextString] = null;
                    HttpContext.Current.Items[LockerString] = null;
                }
    
            }

            _webContext = null;
        }
    }
}
