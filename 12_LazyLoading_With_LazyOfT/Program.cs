using System;
using StructureMap;

namespace _12_LazyLoading_With_LazyOfT
{
    internal class Program
    {
        private static void Main()
        {
            ObjectFactory.Configure(x =>
            {
                x.For(typeof(Lazy<>)).Use(typeof(Lazy<>)).CtorDependency<bool>("isThreadSafe").Is(true);
                x.For<ExpensiveResource>();
                x.For<ThingThatNeedsExpensiveResource>();
            });
            ObjectFactory.AssertConfigurationIsValid();

            var thingThatNeedsExpensiveResource = ObjectFactory.GetInstance<ThingThatNeedsExpensiveResource>();
            Console.WriteLine("Expensive resource has not been initialised yet");
            thingThatNeedsExpensiveResource.UseExpensiveResource();

            Console.ReadKey();
        }
    }

    public class ExpensiveResource
    {
        public ExpensiveResource()
        {
            Console.WriteLine("Expensive resource has now been initialised!");
        }

        public void SayHello()
        {
            Console.WriteLine("Hello World");
        }
    }

    public class ThingThatNeedsExpensiveResource
    {
        private readonly Lazy<ExpensiveResource> _expensiveResource;

        public ThingThatNeedsExpensiveResource(Lazy<ExpensiveResource> expensiveResource)
        {
            _expensiveResource = expensiveResource;
        }

        public void UseExpensiveResource()
        {
            _expensiveResource.Value.SayHello();
        }
    }

}