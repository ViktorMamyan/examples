using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Enumeration
{
    class Program
    {
        static void Main(string[] args)
        {
            var today = DateTime.Now;

            var seq = GenStrings(() =>
                {
                    today += TimeSpan.FromDays(7);
                    return today;
                });

            foreach (var item in seq.Take(100))
                Console.WriteLine(item);

            Console.ReadKey();
        }

        //private static IEnumerable<string> GenStrings()
        //{
        //    int i = 0;
        //    while (i++ < int.MaxValue)
        //        yield return i.ToString();
        //}

        private static IEnumerable<T> GenStrings<T>(Func<T> itemGenerator)
        {
            int i = 0;
            while (i++ < int.MaxValue)
                yield return itemGenerator();
        }

    }
}