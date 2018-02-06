using System;
using System.Collections.Generic;

namespace Loose_Coupling
{
    class Program
    {
        // Define a delegate that accepts a string and returns bool
       // private delegate bool TestDel(string s); // Instead use Func<string, bool>

        static void Main(string[] args)
        {
            string[] items = { "Larry", "Moe", "Curly", "Shemp" };

            // Refactor the standalone TestForLength method as an anonymous method
            int max = 3;
            Func<string, bool> test = delegate(string s) { return s.Length > max; }; // Use lambda

            //string[] result = Where(items, TestForLength);
            //string[] result = Where(items, test); // Use anonymous method
            //string[] result = Where(items, delegate(string s) { return s.Length > max; }); // Use anonymous method as expression
            string[] result = Where(items, s => s.Length > max); // Use lambda expression

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // Create a TestForLength method that matches the delegate
        static bool TestForLength(string s)
        {
            return s.Length > 3;
        }

        // Write a static Where method that accepts a string array and the delegate type
        static string[] Where(string[] items, Func<string, bool> test) // Replace TestDel with Func<string, bool>
        {
            var result = new List<string>();
            foreach (var item in items)
            {
                if (test(item))
                {
                    result.Add(item);
                }
            }
            return result.ToArray();
        }
    }
}
