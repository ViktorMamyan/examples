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
            IList<int> numbers = new List<int> { 1,2,3,10,100,-250,-500,5000};

            Console.WriteLine("Min: {0}",numbers.Min());
            Console.WriteLine("Max: {0}", numbers.Max());
            Console.WriteLine("Avg: {0}", numbers.Average());
            Console.WriteLine("Positiv elements count: {0}", numbers.Where(x => x > 0).Count());
            Console.WriteLine("Positiv elements count: {0}", numbers.Count(x => x > 0));
            Console.WriteLine("Sum of negative elements: {0}", numbers.Where(x => x < 0).Sum());

            Console.ReadKey();
        }
    }

}