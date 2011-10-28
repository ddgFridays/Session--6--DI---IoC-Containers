using System;
using System.Linq;
using TodoList.WithIoC;
using TodoList.WithIoC.IoC;
using TodoList.WithIoC.Models;

namespace _03_What_Is_Inversion_Of_Control
{
    class Program
    {
        static void Main()
        {
            Bootstrapper.Bootstrap();
            var repository = ServiceLocator.GetInstance<ITodoListRepository>();

            repository.Clear();

            var createDIandIoCdemo = new TodoListItem { Description = "Create DI & IoC Demo", DoBy = DateTime.Now };
            var learnRuby = new TodoListItem { Description = "Learn Ruby", DoBy = new DateTime(2012, 1, 1) };

            repository.Add(createDIandIoCdemo);
            repository.Add(learnRuby);

            var allItems = repository.GetAll().ToList();

            allItems.ForEach(item => Console.WriteLine("{0} by {1}", item.Description, item.DoBy.ToShortDateString()));

            Console.ReadKey();
        }
    }
}