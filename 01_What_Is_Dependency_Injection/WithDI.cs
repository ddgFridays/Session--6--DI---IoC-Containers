using TodoList.WithDI;

namespace _01_What_Is_Dependency_Injection
{
    public static class WithDI
    {
        public static TodoListRepository CreateTodoListRepository()
        {
            var configProvider = new ConfigProvider();
            var connectionProvider = new ConnectionProvider(configProvider);
            var databaseProvider = new DatabaseProvider(connectionProvider);
            var dataStore = new DataStore(databaseProvider);
            return new TodoListRepository(dataStore);
        }
    }
}