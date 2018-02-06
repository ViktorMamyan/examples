using System;
using System.Collections.Generic;

namespace Iterators
{
    class Program
    {
        static void Main(string[] args)
        {
            var company = new CompanyOrig("Peter", "Paul", "Mary");
            foreach (var worker in company)
            {
                Console.WriteLine(worker);
            }

            // Write code in Main that initializes an int array and calls GetEvens
            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> evens = GetEvens(ints);
            foreach (var i in evens)
            {
                Console.WriteLine(i);
            }
        }

        // Add a GetEvens method to Main which returns IEnumberable<int> using an iterator
        static IEnumerable<int> GetEvens(IEnumerable<int> ints)
        {
            foreach (var i in ints)
            {
                if (i % 2 == 0)
                    yield return i;
            }
        }
    }
}
