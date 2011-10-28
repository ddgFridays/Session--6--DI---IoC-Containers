using System.Data;
using System.Data.SqlServerCe;
using StructureMap;
using TodoList.WithIoC;
using StructureMap.Configuration.DSL;

namespace _03_What_Is_Inversion_Of_Control
{
    public static class Bootstrapper
    {
        public static void Bootstrap()
        {
            //1. Basic Registration
            UseBasicRegistration();

            //2. Basic Conventional Scanning
            //UseConventionalScanning();

            //3. Specifying a basic convention
            //UseBasicConvention();

            //4. Use Registries
            //UseRegistries();
        }

        private static void UseBasicRegistration()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IConfigProvider>().Singleton().Use<ConfigProvider>();

                x.For<ILogger>().Use<Logger>();

                x.For<IDbConnection>().Use<SqlCeConnection>();
                x.For<IDbConnection>().Use(() => new SqlCeConnection());
                x.For<IConnectionProvider>().Singleton().Use<ConnectionProvider>();

                x.For<IDatabaseProvider>().Use<DatabaseProvider>();
                x.For<IDataStore>().Use<DataStore>();

                x.For<ITodoListRepository>().Use<TodoListRepository>();
            });
            ObjectFactory.AssertConfigurationIsValid();
        }

        private static void UseConventionalScanning()
        {
            ObjectFactory.Initialize(structureMap => structureMap.Scan(scanner =>
            {
                scanner.Assembly("TodoList.WithIoC");
                scanner.WithDefaultConventions();
            }));

            ObjectFactory.Configure(x => x.For<IDbConnection>().Use(() => new SqlCeConnection()));
        }

        private static void UseBasicConvention()
        {
            ObjectFactory.Initialize(structureMap => structureMap.Scan(scanner =>
            {
                scanner.Assembly("TodoList.WithIoC");
                //scanner.IncludeNamespace("TodoList.WithIoC.Repositories");
                scanner.WithDefaultConventions();
                scanner.Convention<SingletonLifecycleConvention>();
            }));

            ObjectFactory.Configure(x => x.For<IDbConnection>().Use(() => new SqlCeConnection()));
        }

        private static void UseRegistries()
        {
            ObjectFactory.Initialize(c => c.Scan(x =>
            {
                x.TheCallingAssembly();
                x.LookForRegistries();
            }));

            ObjectFactory.Configure(x => x.For<IDbConnection>().Use(() => new SqlCeConnection()));
        }
    }

    public class TodoListRegistry : Registry
    {
        public TodoListRegistry()
        {
            For<IConfigProvider>().Singleton().Use<ConfigProvider>();

            For<IDbConnection>().Use(() => new SqlCeConnection());
            For<IConnectionProvider>().Singleton().Use<ConnectionProvider>();

            For<IDatabaseProvider>().Use<DatabaseProvider>();
            For<IDataStore>().Use<DataStore>();

            For<ITodoListRepository>().Use<TodoListRepository>();
        }
    }
}