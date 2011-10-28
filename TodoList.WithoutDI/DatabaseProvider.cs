using TodoList.WithoutDI.Models;

namespace TodoList.WithoutDI
{
    public static class DatabaseProvider
    {
        public static Database GetDatabase()
        {
            var connection = ConnectionProvider.GetConnection();
            return new Database(connection);
        }
    }
}