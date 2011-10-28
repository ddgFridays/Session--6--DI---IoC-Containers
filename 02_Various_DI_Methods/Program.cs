namespace _02_Various_DI_Methods
{
    class Program
    {
        static void Main()
        {
            //We've already seen constructur injection (my prefered, and the most common method)

            //Setter injection is the other alternative (we'll ignore interface injection because it's plain nasty!)
            var thingy = new Thingy { Dependency = new ThingyDependency() };
        }
    }

    public class Thingy
    {
        public ThingyDependency Dependency { get; set; }
    }

    public class ThingyDependency
    {
    }
}