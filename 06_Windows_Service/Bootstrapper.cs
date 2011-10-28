using System.Data;
using System.Data.SqlServerCe;
using StructureMap;
using TodoList.WithIoC;

namespace _06_Windows_Service
{
    public static class Bootstrapper
    {
        public static void Bootstrap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IConfigProvider>().Singleton().Use<ConfigProvider>();

                x.For<IDbConnection>().Use(() => new SqlCeConnection());
                x.For<IConnectionProvider>().Singleton().Use<ConnectionProvider>();

                x.For<IDatabaseProvider>().Use<DatabaseProvider>();
                x.For<IDataStore>().Use<DataStore>();

                x.For<ITodoListRepository>().Use<TodoListRepository>();

                x.For<MyService>();
            });
            ObjectFactory.AssertConfigurationIsValid();
        }
    }
}