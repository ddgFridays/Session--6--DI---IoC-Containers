using System.Collections.Generic;
using TodoList.WithDI.Models;

namespace TodoList.WithDI
{
    public class DataStore
    {
        private readonly Database _database;

        public DataStore(DatabaseProvider databaseProvider)
        {
            _database = databaseProvider.GetDatabase();
        }

        public void Save(object entity)
        {
            _database.Save(entity);
        }

        public T SingleOrDefault<T>(int id)
        {
            return _database.SingleOrDefault<T>("WHERE Id = @Id", new { Id = id });
        }

        public IEnumerable<T> GetAll<T>()
        {
            return _database.Fetch<T>(string.Empty);
        }
    }
}