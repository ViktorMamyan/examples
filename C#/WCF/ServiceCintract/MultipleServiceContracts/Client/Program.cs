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

            int value1 = 50;
            int value2 = 100;

            //basic http (Sum)
            var http_client = new hRef.iSumClient("bhttp");
            http_client.Open();

            Console.WriteLine("HTTP: " + http_client.GetSum(value1,value2));

            http_client.Close();
            
            //net tcp   (Multiple)
            var netTcp_client = new hRef.iMultiplicateClient("ntcp");
            netTcp_client.Open();

            Console.WriteLine("NET.TCP: " + netTcp_client.GetM(value1, value2));

            netTcp_client.Close();

            Console.ReadKey();
        }
    }
}