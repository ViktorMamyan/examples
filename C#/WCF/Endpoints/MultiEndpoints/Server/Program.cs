using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var service = new ServiceHost(typeof(Server.WcfService)))
            {
                service.Open();
                Console.WriteLine("Service Started...");

                Console.ReadKey();
                service.Close();
            }

        }
    }
}