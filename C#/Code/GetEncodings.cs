using System;
using System.Text;

namespace Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press key");
            Console.ReadKey();

            EncodingInfo[] ei = Encoding.GetEncodings();
            foreach(EncodingInfo e in ei)
                Console.WriteLine("{0}: {1}, {2}", e.CodePage, e.Name, e.DisplayName);

            Console.ReadKey();
        }

    }
}