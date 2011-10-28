using System.ServiceProcess;
using TodoList.WithIoC.IoC;

namespace _06_Windows_Service
{
    static class Program
    {
        static void Main()
        {
            Bootstrapper.Bootstrap();
            var service = ServiceLocator.GetInstance<MyService>();
            ServiceBase.Run(service);
        }
    }
}