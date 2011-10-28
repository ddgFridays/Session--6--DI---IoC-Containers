using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.WithIoC;
using TodoList.WithIoC.Models;

namespace _05_ASPNET_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoListRepository _todoListRepository;

        public HomeController(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public ActionResult Index()
        {
            _todoListRepository.Clear();

            var createDIandIoCdemo = new TodoListItem { Description = "Create DI & IoC Demo", DoBy = DateTime.Now };
            var learnRuby = new TodoListItem { Description = "Learn Ruby", DoBy = new DateTime(2012, 1, 1) };

            _todoListRepository.Add(createDIandIoCdemo);
            _todoListRepository.Add(learnRuby);

            var model = _todoListRepository.GetAll().ToList();
            return View(model);
        }
    }
}