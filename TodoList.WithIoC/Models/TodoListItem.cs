using System;

namespace TodoList.WithIoC.Models
{
    public class TodoListItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DoBy { get; set; }
    }
}