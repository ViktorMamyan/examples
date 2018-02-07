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
                if (predicate(item))
                    yield return item;
        }

        //Convert to other data type
        public static IEnumerable<TResult> Select2<TSource,TResult>
                    (this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (TSource item in source)
                yield return selector(item);
        }

        //Custom Index
        public static IEnumerable<TResult> Select3<TSource,TResult>
                    (this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            int index = 0;
            foreach (TSource item in source)
                yield return selector(item,index++);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Linq Select
            var sequence = GetSequence().Select(n => (n * n).ToString());
            //Custom Where
            sequence = sequence.CustomWhere(s => true);

            foreach (var item in sequence)
                Console.WriteLine(item);

            /////////////////////////////////////////////////////////////////////
            Console.WriteLine();

            //Custom Select
            var sequence2 = GetSequence().Select2(n => n * n);

            foreach (var item in sequence2)
                Console.WriteLine(item);

            /////////////////////////////////////////////////////////////////////
            Console.WriteLine();

            //Linq Select with Index
            var sequence3 = GetSequence()
                .Where(n=> n % 5 == 0)
                .Select((n, Index) =>
                new
                    {
                        Index,
                        FormatedResult = n.ToString()
                    });

            foreach (var item in sequence3)
                Console.WriteLine(item);

            /////////////////////////////////////////////////////////////////////
            Console.WriteLine();

            //Custom Index
            var sequence4 = GetSequence()
                .Where(n => n % 5 == 0)
                .Select3((n, Index) =>
                new
                {
                    Index,
                    FormatedResult = n.ToString()
                });

            foreach (var item in sequence4)
                Console.WriteLine(item);

            Console.ReadKey();
        }

        private static IEnumerable<int> GetSequence()
        {
            var i = 0;
            while (i++ < 100)
                yield return i;
        }

    }
}