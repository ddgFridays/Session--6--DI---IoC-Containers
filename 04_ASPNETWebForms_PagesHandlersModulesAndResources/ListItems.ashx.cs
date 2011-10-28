using System.Web;
using TodoList.WithIoC;

namespace _04_ASPNETWebForms_PagesHandlersModulesAndResources
{
    public class ListItems : IHttpHandler
    {
        private readonly ITodoListRepository _todoListRepository;

        public ListItems(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpContext.Current.Response.Write("Handler says: <br />");
            foreach (var item in _todoListRepository.GetAll())
            {
                context.Response.Write(string.Format("Do {0} by {1} <br />", item.Description, item.DoBy));
            }
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}