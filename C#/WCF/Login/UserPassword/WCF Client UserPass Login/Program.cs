using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;

namespace WCF_Win_Auth_Login_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // ignore ssl not trusted certificate 
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            using (var client = new wcfService.iWCFClient())
            { 
                
                //client.ClientCredentials.UserName.UserName = "u";
                //client.ClientCredentials.UserName.Password = "p";

                client.Open();

                client.iInfo();

                Console.WriteLine(client.GetIP2());

                client.Close();

                Console.WriteLine("Finished");
            }
            
            Console.ReadKey();

        }

    }
}