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
            _connectionString = settings["ado"].ConnectionString;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
