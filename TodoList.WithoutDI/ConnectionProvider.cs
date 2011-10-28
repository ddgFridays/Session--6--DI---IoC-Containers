using System.Data;
using System.Data.SqlServerCe;

namespace TodoList.WithoutDI
{
    public static class ConnectionProvider
    {
        public static IDbConnection GetConnection()
        {
            var connectionString = ConfigProvider.GetConnectionString();
            var connection = new SqlCeConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}