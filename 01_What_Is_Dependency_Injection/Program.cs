using System;
using System.Linq;

#if DI
    using TodoList.WithDI.Models;
#else
    using TodoList.WithoutDI.Models;
#endif

namespace _01_What_Is_Dependency_Injection
{
    class Program
    {
        static void Main()
        {
#if DI
            var repository = WithDI.CreateTodoListRepository();
#else
            var repository = WithoutDI.CreateTodoListRepository();
#endif
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