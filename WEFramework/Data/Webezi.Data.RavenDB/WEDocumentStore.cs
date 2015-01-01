using Raven.Client.Document;

namespace WebEzi.Data.RavenDB
{
    public class WEDocumentStore : DocumentStore
    {
        //protected readonly string _connectionString;

        public WEDocumentStore(string connectionStringName)
        {
            //_connectionString = connectionString;
            ConnectionStringName = connectionStringName;

        }
    }
}