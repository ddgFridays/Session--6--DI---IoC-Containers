using System.Collections.Generic;
using TodoList.WithoutDI.Models;

namespace TodoList.WithoutDI
{
    public class TodoListRepository
    {
        public TodoListItem Get(int id)
        {
            var store = new DataStore();
            return store.SingleOrDefault<TodoListItem>(id);
        }

        public void Add(TodoListItem item)
        {
            var store = new DataStore();
            store.Save(item);
        }

        public IEnumerable<TodoListItem> GetAll()
        {
            var store = new DataStore();
            return store.GetAll<TodoListItem>();
        }
    }
}