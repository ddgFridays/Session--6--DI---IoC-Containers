using TodoList.WithoutDI;

namespace _01_What_Is_Dependency_Injection
{
    public static class WithoutDI
    {
        public static TodoListRepository CreateTodoListRepository()
        {
            return new TodoListRepository();
        }
    }
}