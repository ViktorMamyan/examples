using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace Create_SSL_Certificate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Console.ReadKey();

            CreateCert();

            if (CheckIfRuningAsAdministrator() == false)
            {
                Console.WriteLine("Admin Required");
                
                return;
            }

            InstalCert();

            Console.WriteLine("Finished");
            Console.ReadKey();
        }


        static void CreateCert()
        {
            string certName = "CN=MyTestCert";
            string certPath = "mycert.pfx";
            string certPassword = "password123";

            var rsa = RSA.Create();
            var request = new CertificateRequest(certName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            // Optional: Add certificate extensions
            request.CertificateExtensions.Add(
                new X509BasicConstraintsExtension(false, false, 0, false));
            request.CertificateExtensions.Add(
                new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature, false));
            request.CertificateExtensions.Add(
                new X509SubjectKeyIdentifierExtension(request.PublicKey, false));

            // Create self-signed certificate
            var cert = request.CreateSelfSigned(
                DateTimeOffset.Now,
                DateTimeOffset.Now.AddYears(1));

            // Export as PFX
            byte[] pfxBytes = cert.Export(X509ContentType.Pfx, certPassword);
            File.WriteAllBytes(certPath, pfxBytes);

            Console.WriteLine($"Certificate created and saved to {certPath}");
        }

        static void InstalCert()
        {
            string certPath = "mycert.pfx";
            string certPassword = "password123";

            // Load the certificate from file
            var cert = new X509Certificate2(certPath, certPassword, X509KeyStorageFlags.PersistKeySet);

            // Install into Local Machine / Personal store
            using (var store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine))
            {
                store.Open(OpenFlags.ReadWrite);
                store.Add(cert);
                store.Close();
            }

            Console.WriteLine("Certificate installed successfully to Local Machine store.");
        }

        static bool CheckIfRuningAsAdministrator()
        {
            /*
                Replace in config file
                    <requestedExecutionLevel level="asInvoker" uiAccess="false" />
                To
                    <requestedExecutionLevel level="requireAdministrator" uiAccess="false" />
             */

            bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent())
                .IsInRole(WindowsBuiltInRole.Administrator);

            if (!isAdmin)
            {
                Console.WriteLine("Please run as Administrator.");
            }

            return isAdmin;
        }
    }
}