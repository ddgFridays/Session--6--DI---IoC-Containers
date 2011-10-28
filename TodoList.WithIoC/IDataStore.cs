using System.Collections.Generic;

namespace TodoList.WithIoC
{
    public interface IDataStore
    {
        void Save(object entity);
        T SingleOrDefault<T>(int id);
        IEnumerable<T> GetAll<T>();
        void DeleteAll<T>();
    }
}