using TodoList.WithDI.Models;

namespace TodoList.WithDI
{
    public class DatabaseProvider
    {
        private readonly ConnectionProvider _connectionProvider;

        public DatabaseProvider(ConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public Database GetDatabase()
        {
            var connection = _connectionProvider.GetConnection();
            return new Database(connection);
        }
    }
}