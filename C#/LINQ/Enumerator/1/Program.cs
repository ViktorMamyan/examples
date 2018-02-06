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
            ////Old way
            //var sequence = GenStrings();
            //var iterator = sequence.GetEnumerator();
            //for (int i = 0; i < 100; i++)
            //{
            //    if (iterator.MoveNext())
            //        Console.WriteLine(iterator.Current);
            //    else
            //        break;
            //}

            ////new way
            //foreach (var item in GenStrings().Take(100))
            //    Console.WriteLine(item);

            int j = 1;
            var seq = GenStrings(() => j++.ToString());

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