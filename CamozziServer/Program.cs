using System;
using System.Linq;
using System.ServiceModel;
using CServer;
using DataController;

namespace CamozziServer
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(CService)))
            {
                host.Open();
                Console.WriteLine("Host Started...");
                while (true)
                {
                    switch (Console.ReadLine())
                    {
                        case "users":
                        {
                            using (var context = new CamozziEntities())
                            {
                                foreach (var userDb in context.UserDbs)
                                {
                                    Console.WriteLine(userDb.Name+"\n");
                                }
                            }
                            break;
                        }
                        case "proj":
                        {
                            using (var context = new CamozziEntities())
                            {
                                Console.WriteLine(context.ProjectDbs.Count());
                            }
                            break;
                        }
                        case "exit":
                        {
                            
                            //
                        }
                        break;
                        default:
                        {
                            Console.WriteLine("Wrong command");
                            break;
                        }
                    }
                }
                //Console.ReadKey();
            }
        }
    }
}
