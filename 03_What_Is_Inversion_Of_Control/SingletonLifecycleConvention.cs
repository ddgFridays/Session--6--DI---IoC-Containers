using System;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace _03_What_Is_Inversion_Of_Control
{
    public class SingletonLifecycleConvention : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            registry.For(type).Singleton();
        }
    }
}