using System;
using System.Linq;
using AutoMapper;
using StructureMap;
using System.Reflection;

namespace _08_AutoMapper
{
    class Program
    {
        static void Main()
        {
            //Someone asked a question about this when i did AutoMapper....
            Mapper.Initialize(m =>
            {
                var publicTypes = Assembly.GetExecutingAssembly().GetExportedTypes().ToList();
                
                foreach (var viewModelType in publicTypes.Where(t => t.Name.EndsWith("ViewModel")))
                {
                    var entityTypeName = viewModelType.Name.Replace("ViewModel", string.Empty);
                    var entityType = publicTypes.SingleOrDefault(t => t.Name.Equals(entityTypeName));
                    if(entityType != null)
                    {
                        Mapper.CreateMap(entityType, viewModelType);
                    }
                }
            });

            var thingy = new Thingy { Name = "thingy " };
            var otherThingy = new OtherThingy { Name = "otherthingy" };

            var thingyViewModel = Mapper.Map<Thingy, ThingyViewModel>(thingy);
            var otherThingyViewModel = Mapper.Map<OtherThingy, OtherThingyViewModel>(otherThingy);
            Console.WriteLine("thingyViewModel: {0}, otherThingyViewMode; {1}", thingyViewModel.Name, otherThingyViewModel.Name);

            //Using AfterMap to hook up dependencies
            ObjectFactory.Initialize(x =>
            {
                x.For<Source>();
                x.For<Destination>();
                x.For<DestinationDependency>().OnCreationForAll(dependency => dependency.Name = "Hello World");
            });

            Mapper.CreateMap<Source, Destination>()
                  .AfterMap((s, d) => d.Dependency = ObjectFactory.GetInstance<DestinationDependency>());

            var source = new Source { Id = 1, Name = "Thingy" };
            var destination = Mapper.Map<Source, Destination>(source);

            Console.WriteLine("Destination Name: {0}, Dependency: {1}", destination.Name, destination.Dependency.Name);

            
            Console.ReadKey();
        }
    }

    public class Thingy
    {
        public string Name { get; set; }
    }

    public class OtherThingy
    {
        public string Name { get; set; }
    }

    public class ThingyViewModel
    {
        public string Name { get; set; }
    }

    public class OtherThingyViewModel
    {
        public string Name { get; set; }
    }

    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Destination //automapper will only use the empty default constructor, so how do we get our dependency set?
    {
        public DestinationDependency Dependency { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DestinationDependency
    {
        public string Name { get; set; }
    }
}