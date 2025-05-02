using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string thumbprint = "d79716dad08ed125a940d55be02e5ca0bb75253a";
        string appId = "{91715BFA-144A-44D9-A3E3-6CD64C7B5605}"; // Note: 'S' at the end is invalid in a GUID

        string arguments = $"http add sslcert ipport=0.0.0.0:55555 certhash={thumbprint} appid={appId}";

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                Verb = "runas" // Runs with admin privileges
            }
        };

        try
        {
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            Console.WriteLine("Output:\n" + output);
            if (!string.IsNullOrEmpty(error))
                Console.WriteLine("Error:\n" + error);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to run netsh: " + ex.Message);
        }
    }
}