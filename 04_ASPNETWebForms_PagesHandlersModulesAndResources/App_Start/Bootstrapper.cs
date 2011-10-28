using System.Data;
using System.Data.SqlServerCe;
using StructureMap;
using TodoList.WithIoC;
using System.Web;

[assembly: WebActivator.PreApplicationStartMethod(typeof(_04_ASPNETWebForms_PagesHandlersModulesAndResources.App_Start.Bootstrapper), "Bootstrap")]

namespace _04_ASPNETWebForms_PagesHandlersModulesAndResources.App_Start
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

                x.For<IHttpHandler>().Add<ListItems>().Named(typeof(ListItems).Name);
                x.For<IHttpModule>().Add<ListItemsModule>().Named(typeof(ListItemsModule).Name);
            });

            ObjectFactory.AssertConfigurationIsValid();
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