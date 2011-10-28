using TodoList.WithIoC.Models;

namespace TodoList.WithIoC
{
    public interface IDatabaseProvider
    {
        Database GetDatabase();
    }
}