using System.Data;
using System.Data.SqlServerCe;

namespace TodoList.WithDI
{
    public class ConnectionProvider
    {
        private readonly ConfigProvider _config;

        public ConnectionProvider(ConfigProvider config)
        {
            _config = config;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = _config.GetConnectionString();
            var connection = new SqlCeConnection(connectionString); //ugh, explicitly tieing ourselves to Sql Compact Edition here!
            connection.Open();
            return connection;
        }
    }
}