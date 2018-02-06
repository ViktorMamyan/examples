using System;
using System.Collections.Generic;

namespace MyLinq
{
    static class Enumerable
    {
        // Add a public static Where method returning IEnumerable<T>
        // Convert Where to an extension method
        public static IEnumerable<T> Where<T>(this IEnumerable<T> items, Func<T, bool> test)
        {
            // Use an iterator to only return items which pass the test
            foreach (var item in items)
            {
                if (test(item))
                    yield return item;
            }
        }

        // Add a Select extension method with T and TResult type arguments
        public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> items,
            Func<T, TResult> selector)
        {
            foreach (var item in items)
            {
                yield return selector(item);
            }
        }
    }
}
