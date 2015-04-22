using System;
using System.ServiceModel;

namespace CamozziServer
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(CServer.CService)))
            {
                host.Open();
                Console.WriteLine("Host Started...");
                Console.ReadKey();
            }
        }
    }
}
