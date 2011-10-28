using System;
using System.Collections.Generic;
using System.Data;
using TodoList.WithIoC.IoC;

namespace TodoList.WithIoC
{
    public class ConnectionProvider : IConnectionProvider
    {
        private readonly IConfigProvider _config;
        private readonly IList<IDbConnection> _connections = new List<IDbConnection>();

        public ConnectionProvider(IConfigProvider config)
        {
            _config = config;
        }

        public IDbConnection GetConnection()
        {
            var connection = ServiceLocator.GetInstance<IDbConnection>();
            _connections.Add(connection);
            connection.ConnectionString = _config.GetConnectionString();
            connection.Open();
            return connection;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var connection in _connections)
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                    connection.Dispose();
                }
            }
        }
    }
}