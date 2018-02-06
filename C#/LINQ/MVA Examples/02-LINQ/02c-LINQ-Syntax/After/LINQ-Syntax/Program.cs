using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Syntax
{
    class Program
    {
        static void Main(string[] args)
        {
            // Customers in Oakland sorted by last name (operators)
            Console.WriteLine("Customers in Oakland (LINQ operators):");
            var q1 = Data.Customers.Where(c => c.City == "Oakland")
                .OrderBy(c => c.LastName);
            q1.Print();

            // Customers in Oakland sorted by last name (keywords)
            Console.WriteLine("\nCustomers in Oakland (LINQ keywords):");
            var q2 = from c in Data.Customers
                where c.City == "Oakland"   
                orderby c.LastName
                select c;
            q2.Print();

            // Unique list of cities, sorted (operators)
            Console.WriteLine("\nCustomer Cities (LINQ operators):");
            var q3 = Data.Customers.Select(c => c.City).Distinct().OrderBy(s => s);
            q3.Print();

            // Unique list of cities, sorted (keywords with Distinct)
            Console.WriteLine("\nCustomer Cities (LINQ keywords with Distinct):");
            var q4 = (from c in Data.Customers
                orderby c.City
                select c.City).Distinct();
            q4.Print();

            // Customers in list of cities (keywords with Contains)
            Console.WriteLine("\nCustomer in cities (LINQ keywords with Contains:):");
            string[] cities = { "Berkeley", "Palo Alto", "Walnut Creek" };
            var q5 = from c in Data.Customers
                where cities.Contains(c.City)
                select c;
            q5.Print();

            // Do any customers have more than 100,000 orders?
            bool any = Data.Customers.Any(c => c.Orders > 100000);
            Console.WriteLine("\nCustomers with orders greater than 100,000 (Any): {0}", any);

            // Get first three customers
            Console.WriteLine("\nFirst three customers:");
            var q6 = Data.Customers.Take(3);
            q6.Print();

            // Reverse them
            Console.WriteLine("\nFirst three customers in reverse:");
            var reverse = q6.Reverse();
            reverse.Print();

            // Empty sequence of customers
            var empty = Enumerable.Empty<Customer>();
            Console.WriteLine("\nCustomers in Empty: {0}", empty.Count());
        }
    }

    static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
                Console.WriteLine(item);
        }
    }
}
