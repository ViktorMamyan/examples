using System;
using System.Collections.Generic;
using System.Linq;
using SampleData;

namespace Grouping_Joining
{
    class Program
    {
        static void Main(string[] args)
        {
            // Query books, use let to calculate tax and total price
            // Use tax and total in where and select clauses
            Console.WriteLine("Use 'let' to declare inline variables:");
            var q1 = from b in LinqBooks.Books
                let tax = b.Price*.0825M
                let total = b.Price + tax
                where total > 20
                select new {b.Title, b.Price, Tax = tax, Total = total};
            q1.Print();

            // Use multiple from clauses to get all child objects
            // Add Distinct and OrderBy operations
            Console.WriteLine("\nChain 'from' clauses to get all book authors");
            var q2 = (from b in LinqBooks.Books
                from a in b.Authors
                select a).Distinct().OrderBy(a => a.LastName);
            q2.Print();

            // Group books by price
            Console.WriteLine("\nGroup books by price:");
            var q3 = from b in LinqBooks.Books
                group b by b.Price;
            foreach (var g in q3)
            {
                Console.WriteLine(g.Key);
                foreach (var b in g)
                    Console.WriteLine("\t{0}", b.Title);
            }

            // Group books by price, then sort the groups
            Console.WriteLine("\nUse 'into' to sort groups:");
            var q4 = from b in LinqBooks.Books
                     orderby b.Title
                     group b by b.Price into g
                     orderby g.Key descending 
                     select g;
            foreach (var g in q4)
            {
                Console.WriteLine(g.Key);
                foreach (var b in g)
                    Console.WriteLine("\t{0}", b.Title);
            }

            // Join authors with names
            Console.WriteLine("\nJoin Authors with Names:");
            var q5 = from a in LinqBooks.Authors
                join n in Data.Names 
                     on a.FirstName equals n
                select a;
            q5.Print();

            // Create group join between authors and hobbies using 'into'
            Console.WriteLine("\nJoin Authors with Hobbies (Group Join):");
            var q6 = from a in LinqBooks.Authors
                join ah in Data.AuthorHobbies
                    on a.FirstName equals ah.Name into hobbies
                select new
                {
                    Name = string.Format("{0} {1}", a.FirstName, a.LastName),
                    Hobbies = hobbies
                };
            foreach (var a in q6)
            {
                Console.WriteLine(a.Name);
                foreach (var h in a.Hobbies)
                    Console.WriteLine("\t{0}", h.Hobby);
            }

            // Create outer join between authors and hobbies using DefaultIfEmpty
            Console.WriteLine("\nJoin Authors with Hobbies (Outer Join):");
            var q7 = from a in LinqBooks.Authors
                join ah in Data.AuthorHobbies
                    on a.FirstName equals ah.Name into hobbies
                from h in hobbies.DefaultIfEmpty()
                select new
                {
                    Name = string.Format("{0} {1}", a.FirstName, a.LastName),
                    Hobby = h != null ? h.Hobby : string.Empty
                };
            q7.Print();
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
