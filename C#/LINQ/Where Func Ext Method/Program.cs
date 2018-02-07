using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Where_Select
{
    public static class LinqImplementation
    {
        //Custom Where Extention Method
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
                if(predicate(item))
                    yield return item;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Linq Where
            var sequence = GetSequence();
            sequence = sequence.Where(s => s.Length < 2);

            foreach (var item in sequence)
                Console.WriteLine(item);

            //Custom Where
            var sequence2 = GetSequence();
            sequence2 = sequence2.CustomWhere(s => s.Length < 2);

            foreach (var item in sequence2)
                Console.WriteLine(item);

            Console.ReadKey();
        }

        private static IEnumerable<string> GetSequence()
        {
            var i = 0;
            while (i++ < 100)
                yield return i.ToString();
        }

    }
}