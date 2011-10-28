using System.Collections.Generic;
using TodoList.WithIoC.Models;

namespace TodoList.WithIoC
{
    public interface ITodoListRepository
    {
        TodoListItem Get(int id);
        void Add(TodoListItem item);
        IEnumerable<TodoListItem> GetAll();
        void Clear();
    }
}