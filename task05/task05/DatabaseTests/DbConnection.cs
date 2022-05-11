using System.Configuration;

namespace DatabaseTests
{
    public class DbConnection
    {
        private string _connectionString;
        private static DbConnection _instance;
        
        public static DbConnection Instance
        {
            get { return _instance; }
        }
        static DbConnection()
        {
            _instance = new DbConnection();
        }

        private DbConnection()
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            //_connectionString = settings["ado"].ConnectionString;
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=librarydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
