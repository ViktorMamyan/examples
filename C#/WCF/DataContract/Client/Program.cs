using Client.hRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // ignore ssl not trusted certificate 
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var http_client = new hRef.CarListClient("bhttp");
            http_client.Open();

            Car c = new Car();
            c.ՀՀ = 5;
            c.Model = "Model";
            c.Vendor = "Vendor";
            c.Year = 2018;

            http_client.SetCar(c);

            Console.WriteLine("Set");

            c = http_client.GetCar(1);

            Console.WriteLine("Set");

            Console.WriteLine(c.ToString());

            http_client.Close();
            
            Console.ReadKey();
        }
    }
}