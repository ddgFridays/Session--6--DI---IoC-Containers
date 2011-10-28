using System.IO;
using System.Reflection;

namespace TodoList.WithIoC
{
    public class ConfigProvider : IConfigProvider
    {
        public string GetConnectionString()
        {
            return "Data Source=TodoListDB.sdf;Persist Security Info=False;";
        }
    }
}