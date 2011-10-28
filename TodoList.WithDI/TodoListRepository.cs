using System.Collections.Generic;
using TodoList.WithDI.Models;

namespace TodoList.WithDI
{
    public class TodoListRepository
    {
        private readonly DataStore _store;

        public TodoListRepository(DataStore store)
        {
            _store = store;
        }

        public TodoListItem Get(int id)
        {
            return _store.SingleOrDefault<TodoListItem>(id);
        }

        public void Add(TodoListItem item)
        {
            _store.Save(item);
        }

        public IEnumerable<TodoListItem> GetAll()
        {
            return _store.GetAll<TodoListItem>();
        }
    }
}