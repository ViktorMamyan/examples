using System;
using System.CodeDom;
using System.Collections.Generic;

namespace ExtensionMethods
{
    // Bring Where into scope
    using MyLinq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Call where as a classic static method
            //IEnumerable<int> evens = MyLinq.Enumerable.Where(ints, i => i % 2 == 0);

            // Call Where as an extension method
            IEnumerable<int> evens = ints.Where(i => i % 2 == 0);
            foreach (var i in evens)
            {
                Console.WriteLine(i);
            }

            // Array of strings
            string[] strings = { "Manny", "Moe", "Jack" };

            // Call Select to return anonymous types
            var folks = strings.Select(s => new {Name = s, Age = s.Length});
            foreach (var f in folks)
            {
                Console.WriteLine(f);
            }
        }
    }
}
