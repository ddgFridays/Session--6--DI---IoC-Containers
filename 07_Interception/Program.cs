using System;
using StructureMap;
using StructureMap.Interceptors;

namespace _07_Interception
{
    class Program
    {
        static void Main()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<OnCreationThingy>().OnCreationForAll(thingy => Console.WriteLine("Created an OnCreationThingy"));
                
                x.For<IEnriched>().Use<EnrichMeThingy>().EnrichWith(thingy =>
                {
                    var enrichedThingy = new EnrichedThingy(thingy);
                    Console.WriteLine(enrichedThingy.ToString());
                    return enrichedThingy;
                });
                x.For<InterceptedThingy>().InterceptWith(new MyInterceptor());
            });

            Console.WriteLine("Creating an OnCreationThingy");
            var onCreationThingy = ObjectFactory.GetInstance<OnCreationThingy>();

            Console.WriteLine("Creating an EnrichWithThingy");
            var enrichMeThingy = ObjectFactory.GetInstance<IEnriched>();

            Console.WriteLine("Creating an InterceptedThingy");
            var interceptedThingy = ObjectFactory.GetInstance<InterceptedThingy>();

            Console.ReadKey();
        }
    }

    public class OnCreationThingy
    {
        
    }

    public interface IEnriched
    {
    }

    public class EnrichMeThingy : IEnriched
    {
        public override string ToString()
        {
            return "Hello";
        }
    }

    public class EnrichedThingy : IEnriched
    {
        private readonly EnrichMeThingy _otherThingy;

        public EnrichedThingy(EnrichMeThingy otherThingy)
        {
            _otherThingy = otherThingy;
        }

        public override string ToString()
        {
            return _otherThingy + " world";
        }
    }

    public class InterceptedThingy
    {
        
    }

    public class MyInterceptor : InstanceInterceptor
    {
        public object Process(object target, IContext context)
        {
            Console.WriteLine("Intercepted: " + target.GetType().Name);
            return target;
        }
    }
}