using System;
using System.Collections.Generic;
using System.IdentityModel.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Listening on ...");

            using (var host = new ServiceHost(typeof(WCFClass)))
            {
                host.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = System.ServiceModel.Security.UserNamePasswordValidationMode.Custom;
                host.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new CustomValidator.CheckPassword(); 

                host.Open();
                host.Description.Endpoints.ToList().ForEach(ep => Console.WriteLine(ep.Address));
                Console.ReadKey();
                host.Close();
            }

            //Console.ReadKey();

        }
    }

}