using System.Collections.Generic;
using TodoList.WithIoC.Models;

namespace TodoList.WithIoC
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly IDataStore _store;

        public TodoListRepository(IDataStore store)
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

        public void Clear()
        {
            _store.DeleteAll<TodoListItem>();
        }
    }
}