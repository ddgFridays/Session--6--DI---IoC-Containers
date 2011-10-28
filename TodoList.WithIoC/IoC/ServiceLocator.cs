using System;
using System.Collections.Generic;
using StructureMap;

namespace TodoList.WithIoC.IoC
{
    public static class ServiceLocator
    {
        public static T GetInstance<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }

        public static T GetInstance<T>(string name)
        {
            return ObjectFactory.GetNamedInstance<T>(name);
        }

        public static object GetInstance(Type type)
        {
            return ObjectFactory.GetInstance(type);
        }

        public static IEnumerable<T> GetInstances<T>()
        {
            return ObjectFactory.GetAllInstances<T>();
        }

        public static void ReleaseAndDisposeAllHttpScopedObjects()
        {
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }
    }
}