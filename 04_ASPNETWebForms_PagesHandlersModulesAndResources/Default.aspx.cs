using System;
using System.Web.UI;
using TodoList.WithIoC;
using TodoList.WithIoC.Models;

namespace _04_ASPNETWebForms_PagesHandlersModulesAndResources
{
    public partial class Default : Page
    {
        private readonly ITodoListRepository _todoListRepository;

        protected Default() { }

        public Default(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _todoListRepository.Clear();

            var createDIandIoCdemo = new TodoListItem { Description = "Create DI & IoC Demo", DoBy = DateTime.Now };
            var learnRuby = new TodoListItem { Description = "Learn Ruby", DoBy = new DateTime(2012, 1, 1) };

            _todoListRepository.Add(createDIandIoCdemo);
            _todoListRepository.Add(learnRuby);

            todoListItemDisplay.DataSource = _todoListRepository.GetAll();
            todoListItemDisplay.DataBind();
        }
    }
}