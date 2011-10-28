using System;
using StructureMap;

namespace _10_Conditional
{
    class Program
    {
        static void Main()
        {
            ObjectFactory.Initialize(x => x.For<IDisplayer>().ConditionallyUse(d =>
            {
                d.TheDefault.Is.Type<DisabledDisplayer>();

                d.If(c => Context.CurrentUser.Enabled).ThenIt.Is.Type<EnabledDisplayer>();
            }));

            var displayer = ObjectFactory.GetInstance<IDisplayer>();

            Console.WriteLine(displayer.Display());
            Console.ReadKey();
        }
    }

    public static class Context
    {
        public static User CurrentUser
        {
            get { return new User { Enabled = true }; }
        }
    }

    public class User
    {
        public bool Enabled { get; set; }
    }

    public interface IDisplayer
    {
        string Display();
    }

    public class EnabledDisplayer : IDisplayer
    {
        public string Display()
        {
            return "Hello World";
        }
    }

    public class DisabledDisplayer : IDisplayer
    {
        public string Display()
        {
            return "You're disabled from view this section.";
        }
    }
}