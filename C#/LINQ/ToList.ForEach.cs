using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        list
            .Where(n => n > 5)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}