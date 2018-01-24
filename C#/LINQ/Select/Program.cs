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
            IList<int> numbers = new List<int> {1,10,100,50,90,0,999,5400,9900};

            foreach (var number in numbers.Select((x, index) => new {Number = x, Index = index}).Where(x=> x.Number % 2 ==0))
            {
                Console.WriteLine(number.Index.ToString() + "\t" + number.Number.ToString());
            }

            Console.ReadKey();
        }
    }

}