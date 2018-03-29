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

            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                Console.WriteLine($"Drive Name: {di.Name} \nDrive Type: {di.DriveType}");
                //AvailableFreeSpace
                //DriveFormat
                //IsReady
                //RootDirectory
                //TotalFreeSpace
                //TotalSize
                //VolumeLabel
            }

            Console.ReadKey();
        }
    }
}