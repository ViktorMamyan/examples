using System;
using System.IO;

namespace Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press key");
            Console.ReadKey();

            // Create an instance of FileSystemWatcher
            FileSystemWatcher fsw = new
            FileSystemWatcher(Environment.GetEnvironmentVariable("USERPROFILE"));

            // Set the FileSystemWatcher properties
            fsw.IncludeSubdirectories = true;

            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
            
            // Add the Changed event handler
            fsw.Changed += new FileSystemEventHandler(fsw_Changed);
            
            // Start monitoring events
            fsw.EnableRaisingEvents = true;

            Console.ReadKey();
        }

        static void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            // Write the path of a changed file to the console
            Console.WriteLine(e.ChangeType + ": " + e.FullPath);
        }

    }
}