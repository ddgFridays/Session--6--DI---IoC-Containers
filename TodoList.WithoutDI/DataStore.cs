using System.Collections.Generic;

namespace TodoList.WithoutDI
{
    public class DataStore
    {
        public void Save(object entity)
        {
            var database = DatabaseProvider.GetDatabase();
            database.Save(entity);
        }

        public T SingleOrDefault<T>(int id)
        {
            var database = DatabaseProvider.GetDatabase();
            return database.SingleOrDefault<T>("WHERE Id = @Id", new { Id = id });
        }

        public IEnumerable<T> GetAll<T>()
        {
            var database = DatabaseProvider.GetDatabase();
            return database.Fetch<T>(string.Empty);
        }
    }
}