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

            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");

            Console.WriteLine("Folders:");
            foreach (DirectoryInfo dirInfo in dir.GetDirectories())
                Console.WriteLine("\t" + dirInfo.Name);

            Console.WriteLine("\nFiles:");
            foreach (FileInfo fi in dir.GetFiles())
                Console.WriteLine("\t" + fi.Name);

            Console.ReadKey();
        }
    }
}