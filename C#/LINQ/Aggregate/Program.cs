using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> country = new List<string> {"US","UK","AM","FR"};

            Console.WriteLine(country.Aggregate((a,b) => a + " - " + b));

            Console.ReadKey();
        }
    }

}