using System;
using System.Data;

namespace TodoList.WithIoC
{
    public interface IConnectionProvider : IDisposable
    {
        IDbConnection GetConnection();
    }
}