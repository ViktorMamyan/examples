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
                 //client.ClientCredentials.Windows.ClientCredential.UserName = "User";
                //client.ClientCredentials.Windows.ClientCredential.Password = "Password";

                client.Open();

                client.iInfo();

                //Console.WriteLine("IP: {0}",client.GetIP());

                //Console.WriteLine( client.jInfo());

                //Console.WriteLine(client.State.ToString());

                Console.WriteLine(client.GetIP2());

                client.Close();

                Console.WriteLine("Finished");
            }
            
            Console.ReadKey();

        }

    }
}