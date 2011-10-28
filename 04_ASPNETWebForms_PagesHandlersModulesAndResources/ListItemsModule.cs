using System;
using System.Web;
using TodoList.WithIoC;

namespace _04_ASPNETWebForms_PagesHandlersModulesAndResources
{
    public class ListItemsModule : IHttpModule
    {
        private readonly ITodoListRepository _todoListRepository;

        public ListItemsModule(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }

        void OnBeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.RawUrl.Contains("module"))
            {
                HttpContext.Current.Response.ContentType = "text/html";
                HttpContext.Current.Response.Write("Module says: <br />");
                foreach (var item in _todoListRepository.GetAll())
                {
                    HttpContext.Current.Response.Write(string.Format("Do {0} by {1} <br />", item.Description, item.DoBy));
                }
                HttpContext.Current.Response.End();
            }
        }
    }
}