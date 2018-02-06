using System;
using System.Collections.Generic;
using System.Linq;

namespace Conversion_Aggregation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Select single customer from Oakland
            //var c1 = Data.Customers.Single(c => c.City == "Oakland");

            // Select single customer from Los Angeles
            //var c2 = Data.Customers.Single(c => c.City == "Los Angeles");

            // Select single customer from San Francisco
            Console.WriteLine("Single customer:");
            var c3 = Data.Customers.Single(c => c.City == "San Francisco");
            Console.WriteLine(c3);

            // Select single customer or default from Oakland
            //var c4 = Data.Customers.SingleOrDefault(c => c.City == "Oakland");

            // Select single customer from Los Angeles
            var c5 = Data.Customers.SingleOrDefault(c => c.City == "Los Angeles");
            Console.WriteLine("\nCustomer from Los Angeles: {0}", 
                c5 == null ? "None" : c5.ToString());

            // Cache by converting to a list
            Console.WriteLine("\nOakland customers (IEnumerable):");
            var q1 = from c in Data.Customers
                where c.City == "Oakland" // Set breakpoint here (line 31)
                select c;
            q1.Print(); // And here - will hit line 31

            Console.WriteLine("\nOakland customers (List):");
            var customersList = q1.ToList(); // And here - will hit line 31
            customersList.Print(); // And here - will *not* hit line 31

            // Convert to a dictionary with FirstName + " " + LastName as key
            var q2 = Data.Customers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName);
            var customersDict = q2.ToDictionary(c => c.FirstName + " " + c.LastName);
            var c6 = customersDict["Johnson Smith"];
            Console.WriteLine("\nFrom Customer Dictionary: {0}", c6);

            // Convert to a lookup with City as the key
            Console.WriteLine("\nCustomers grouped by City in a Lookup:");
            var lookup = Data.Customers.ToLookup(c => c.City);
            foreach (var cityGroup in lookup)
            {
                Console.WriteLine(cityGroup.Key);
                foreach (var c in cityGroup)
                    Console.WriteLine("\t{0}", c);
            }

            // Count number of customers from Oakland
            var count = Data.Customers.Count(c => c.City == "Oakland");
            Console.WriteLine("\nCustomers from Oakland Count: {0}", count);

            // Customer with fewest orders
            var c7 = (from c in Data.Customers
                where c.Orders == Data.Customers.Min(cu => cu.Orders)
                select c).Single();
            Console.WriteLine("\nCustomer with fewest orders: {0}", c7);

            // Average orders for customers in Oakland
            var average = (from c in Data.Customers
                where c.City == "Oakland"
                select c).Average(c => c.Orders);
            Console.WriteLine("\nAverage orders from Oakland: {0}", average);

            // See if there are any customers with less than 5000 orders
            var result = Data.Customers.Any(c => c.Orders < 5000);
            Console.WriteLine("\nAny orders less than 5000: {0}", result);
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
