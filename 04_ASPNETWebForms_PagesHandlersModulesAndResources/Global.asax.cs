using System;
using System.Linq;
using System.Web;
using TodoList.WithIoC.IoC;

namespace _04_ASPNETWebForms_PagesHandlersModulesAndResources
{
    public class Global : HttpApplication
    {
        public override void Init()
        {
            base.Init();
            ServiceLocator
                .GetInstances<IHttpModule>()
                .ToList()
                .ForEach(module => module.Init(this));
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            ServiceLocator.ReleaseAndDisposeAllHttpScopedObjects();
        }
    }
}