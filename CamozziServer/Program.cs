using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

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
