using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace _13_More_Constructur_Injection
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //If all the constructor arguments have differing types you can just do:
            ObjectFactory.Initialize(x => x
                .For<Person>()
                .Use<Person>()
                .Ctor<string>().Is("Alex")
                .Ctor<int>().Is(15));

            Console.WriteLine(ObjectFactory.GetInstance<Person>());

            //otherwise you have to specify the names of the arguments like so:
            ObjectFactory.Configure(x => x
                .For<Point>()
                .Use<Point>()
                .Ctor<int>("x").Is(5)
                .Ctor<int>("y").Is(2));

            Console.WriteLine(ObjectFactory.GetInstance<Point>());

            Console.ReadKey();
        }
    }

    public class Person
    {
        private readonly string _name;
        private readonly int _age;

        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public override string ToString()
        {
            return string.Format("My name is {0} and I am {1} years old.", _name, _age);
        }
    }

    public class Point
    {
        private readonly int _x;
        private readonly int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}", _x, _y);
        }
    }
}