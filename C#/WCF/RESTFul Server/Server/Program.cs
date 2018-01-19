using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFCode
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var service = new ServiceHost(typeof(WCFCode.XServer)))
            {
                service.Open();
                Console.WriteLine("Service Started...");

                Console.ReadKey();
                service.Close();
            }
        }
    }
}