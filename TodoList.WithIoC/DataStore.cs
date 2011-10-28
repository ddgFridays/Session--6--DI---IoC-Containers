using System.Collections.Generic;

namespace TodoList.WithIoC
{
    public class DataStore : IDataStore
    {
        private readonly IDatabaseProvider _databaseProvider;

        public DataStore(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public void Save(object entity)
        {
            _databaseProvider.GetDatabase().Save(entity);
        }

        public T SingleOrDefault<T>(int id)
        {
            return _databaseProvider.GetDatabase().SingleOrDefault<T>("WHERE Id = @Id", new { Id = id });
        }

        public IEnumerable<T> GetAll<T>()
        {
            return _databaseProvider.GetDatabase().Fetch<T>(string.Empty);
        }

        public void DeleteAll<T>()
        {
            _databaseProvider.GetDatabase().Delete<T>(string.Empty);
        }
    }
}