namespace TodoList.WithDI
{
    public class ConfigProvider
    {
        public string GetConnectionString()
        {
            return "DataSource=TodoListDB.sdf";
        }
    }
}