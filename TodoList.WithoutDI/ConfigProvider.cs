namespace TodoList.WithoutDI
{
    public static class ConfigProvider
    {
        public static string GetConnectionString()
        {
            return "DataSource=TodoListDB.sdf";
        }
    }
}