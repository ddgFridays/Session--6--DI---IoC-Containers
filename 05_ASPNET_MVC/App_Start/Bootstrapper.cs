using System.Data;
using System.Data.SqlServerCe;
using System.Web.Mvc;
using StructureMap;
using TodoList.WithIoC;

[assembly: WebActivator.PreApplicationStartMethod(typeof(_05_ASPNET_MVC.App_Start.Bootstrapper), "Bootstrap")]

namespace _05_ASPNET_MVC.App_Start
{
    public static class Bootstrapper
    {
        public static void Bootstrap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IConfigProvider>().Singleton().Use<ASPNETConfigProvider>();

                x.For<IDbConnection>().Use(() => new SqlCeConnection());
                x.For<IConnectionProvider>().HybridHttpOrThreadLocalScoped().Use<ConnectionProvider>();

                x.For<IDatabaseProvider>().Use<DatabaseProvider>();
                x.For<IDataStore>().Use<DataStore>();

                x.For<ITodoListRepository>().Use<TodoListRepository>();
            });

            ObjectFactory.AssertConfigurationIsValid();

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
        }
    }

    public class ASPNETConfigProvider : IConfigProvider
    {
        public string GetConnectionString()
        {
            return "Data Source=|DataDirectory|TodoListDB.sdf;Persist Security Info=False;";
        }
    }
}