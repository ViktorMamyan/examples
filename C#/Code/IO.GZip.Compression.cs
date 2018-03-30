using System;
using System.IO;
using System.IO.Compression;

namespace Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press key");
            Console.ReadKey();

            GZipStream gzOut = new GZipStream(File.Create("Data.Zip"),CompressionMode.Compress);

            StreamWriter sw = new StreamWriter(gzOut);

            for (int i = 0; i < 1000; i++)
            {
                sw.Write(i);
            }

            sw.Close();
            gzOut.Close();

            GZipStream gzIn = new GZipStream(File.OpenRead("Data.Zip"),CompressionMode.Decompress);
            StreamReader sr = new StreamReader(gzIn);
            Console.WriteLine(sr.ReadToEnd());

            sr.Close();
            gzIn.Close();

            Console.ReadKey();
        }

    }
}