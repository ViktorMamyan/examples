﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Syntax
{
    class Program
    {
        static void Main(string[] args)
        {
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
