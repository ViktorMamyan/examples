﻿using System;
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
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            int value1 = 50;
            int value2 = 100;

            //basic http
            var http_client = new hRef.WcfServiceClient("bhttp");
            http_client.Open();

            Console.WriteLine("HTTP: " + http_client.GetSum(value1,value2));

            http_client.Close();
            
            //net tcp
            var netTcp_client = new hRef.WcfServiceClient("ntcp");
            netTcp_client.Open();

            Console.WriteLine("NET.TCP: " + netTcp_client.GetSum(value1, value2));

            netTcp_client.Close();


            //https
            var https_client = new hRef.WcfServiceClient("https");
            https_client.Open();

            Console.WriteLine("HTTPS: " + https_client.GetSum(value1, value2));

            https_client.Close();

            Console.ReadKey();
        }
    }
}