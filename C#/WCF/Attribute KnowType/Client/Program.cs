using Client.hRef;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var https_client = new hRef.CarListClient("https");
            https_client.Open();

            Car c;

            c = new PassengerCar();

            c.ՀՀ = 5;
            c.Model = "Model";
            c.Vendor = "Vendor";
            c.Year = 2018;
            ((PassengerCar)c).Passengers = 25;

            https_client.SetCar(c);

            Console.WriteLine("Set");

            c = https_client.GetCar(5);

            Console.WriteLine("Get");

            Console.WriteLine(((PassengerCar)c).Passengers.ToString());

            https_client.Close();
            
            Console.ReadKey();
        }
    }
}