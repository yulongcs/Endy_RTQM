using System.Web.Caching;

namespace WebEzi.Core.Domain.Base.Cache
{
    public class CacheNotification
    {
        private static CacheNotification _helper;

        private string[] EnabledTables { get; set;}
        private string ConnectionString { get; set; }

        public static CacheNotification GetInstance(string connectionString)
        {
            if (_helper == null)
            {
                SqlCacheDependencyAdmin.EnableNotifications(connectionString);

                _helper = new CacheNotification();
                _helper.EnabledTables = SqlCacheDependencyAdmin.GetTablesEnabledForNotifications(connectionString);
                _helper.ConnectionString = connectionString;
            }
            return _helper;
        }

        public void EnableTableForNotifications(string tableName)
        {
            bool tableExist = false;
            foreach (var table in EnabledTables)
            {
                if (table == tableName)
                {
                    tableExist = true;

                    break;
                }
            }

            if (!tableExist)
            {
                SqlCacheDependencyAdmin.EnableTableForNotifications(ConnectionString, tableName);
            }
        }
    }
}