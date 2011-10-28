using System.Web;
using TodoList.WithIoC.IoC;

namespace _04_ASPNETWebForms_PagesHandlersModulesAndResources
{
    public class ServiceLocatorHttpHandlerFactory : IHttpHandlerFactory
    {
        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            var handlerName = url.Substring(1).Replace(".ashx", string.Empty);
            return ServiceLocator.GetInstance<IHttpHandler>(handlerName);
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
        }
    }
}