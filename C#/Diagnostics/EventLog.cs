using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Admin required
            EventLog.WriteEntry("XXXAPP", "Started");

            Console.WriteLine("OK");

            Console.ReadKey();

            EventLog.WriteEntry("XXXAPP", "Ended");

            //OR

            if (!EventLog.SourceExists("XApp"))
            {
                EventLog.CreateEventSource("XApp","Application");
            }
            EventLog.WriteEntry("XApp", "Started");

        }
    }
}