using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            string Hello = "Hello";
            Hello.WriteToConsole();

            Console.ReadKey();
        }
    }

    public static class ExtensoinsClass
    {
        public static void WriteToConsole(this string content)
        {
            Console.WriteLine(content);
        }    
    }

}