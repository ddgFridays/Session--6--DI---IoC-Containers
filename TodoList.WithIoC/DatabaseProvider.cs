using TodoList.WithIoC.Models;

namespace TodoList.WithIoC
{
    public class DatabaseProvider : IDatabaseProvider
    {
        private readonly IConnectionProvider _connectionProvider;

        public DatabaseProvider(IConnectionProvider connectionProvider)
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