using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var https_client = new ServerRef.XServerClient("https");
            https_client.Open();

            Console.WriteLine("Press any key");
            Console.ReadKey();

            try
            {
                Console.WriteLine(https_client.Divide(1, 0));

                Console.WriteLine(https_client.Divide(1, 1));
            }
            catch (System.ServiceModel.FaultException fe)
            {
                Console.WriteLine(fe.Message);
                Console.WriteLine("\n\n");
                //Console.WriteLine(fe.GetType());
                Console.WriteLine("\nFault Exeption\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine("\n\n");
                //Console.WriteLine(ex.GetType());
                //Console.WriteLine("\n\n");
            }
            
            Console.WriteLine(https_client.State.ToString());

            Console.WriteLine(https_client.Divide(20, 5));

            https_client.Close();

            Console.ReadKey();
        }
    }
}