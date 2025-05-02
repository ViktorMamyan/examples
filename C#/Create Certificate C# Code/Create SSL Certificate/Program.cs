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

            GetThumbprint();

            //CheckIfCertificateInstalled2("abc.com");

            //string thumbprint = "3F900CFE734BD3320A962E7D83C6D5C31C47B1F9";
            //bool IsInstalled = CheckIfCertificateInstalled(thumbprint);
            //Console.WriteLine(IsInstalled);

            

            //if (CheckIfRuningAsAdministrator() == false)
            //{
            //    Console.WriteLine("Admin Required");

            //    return;
            //}

            //InstalCert();

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

        static bool CheckIfCertificateInstalled(string thumbprint)
        {
            thumbprint = thumbprint.Replace(" ", "").ToUpperInvariant();

            using (var store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
            {
                store.Open(OpenFlags.ReadOnly);
                var certs = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, validOnly: false);

                if (certs.Count > 0)
                {
                    Console.WriteLine("Certificate is already installed.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Certificate not found.");
                    return false;
                }
            }
        }

        static bool CheckIfCertificateInstalled2(string domain)
        {
            using (var store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
            {
                store.Open(OpenFlags.ReadOnly);
                //store.Certificates.Find(X509FindType.FindBySubjectName, "mydomain.com", false);

                var certs = store.Certificates.Find(X509FindType.FindBySubjectName, domain, false);

                if (certs.Count > 0)
                {
                    Console.WriteLine("Certificate is already installed.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Certificate not found.");
                    return false;
                }
            }
        }

        //Get Thumbprint from .pfx or .cer
        static string GetThumbprint()
        {
            string certPath = "mycert.pfx";           // or "mycert.cer"
            string certPassword = "password123";      // needed only for .pfx files

            var cert = new X509Certificate2(certPath, certPassword);

            Console.WriteLine("Thumbprint: " + cert.Thumbprint);

            string thumbprint = cert.Thumbprint?.Replace(" ", "").ToUpperInvariant();

            return thumbprint;
        }

    }
}