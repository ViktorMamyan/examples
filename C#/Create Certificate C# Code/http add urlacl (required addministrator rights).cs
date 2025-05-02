using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = @"http add urlacl url=https://+:55555/ user=\Everyone",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                Verb = "runas" // This runs as Administrator
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
