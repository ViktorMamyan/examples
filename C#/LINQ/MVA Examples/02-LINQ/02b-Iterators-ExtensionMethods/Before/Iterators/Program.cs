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
        }
    }
}
