using System;
using StructureMap;

namespace _09_Generics
{
    class Program
    {
        static void Main()
        {
            ObjectFactory.Initialize(x => x.For(typeof(IRepository<>)).Use(typeof(Repository<>)));

            var thingyRepository = ObjectFactory.GetInstance<IRepository<Thingy>>();
            var thingy = thingyRepository.Get(id: 1);

            Console.WriteLine(thingyRepository.GetType().GetGenericArguments()[0].Name + " repository loaded a " + thingy.GetType().Name);

            Console.ReadKey();
        }
    }

    public interface IRepository<T> where T : class, new()
    {
        T Get(int id);
    }

    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public virtual T Get(int id)
        {
            return new T();
        }
    }

    public class Thingy
    {
    }
}