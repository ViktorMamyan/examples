using System;
using System.Collections.Generic;
using System.Linq;

namespace Operators {
   class DefaultEmpty {
      static void Main(string[] args) {
         Pet barley = new Pet() { Name = "Barley", Age = 4 };
         Pet boots = new Pet() { Name = "Boots", Age = 1 };
         Pet whiskers = new Pet() { Name = "Whiskers", Age = 6 };
         Pet bluemoon = new Pet() { Name = "Blue Moon", Age = 9 };
         Pet daisy = new Pet() { Name = "Daisy", Age = 3 };

         List<Pet> pets = new List<Pet>() { barley, boots, whiskers, bluemoon, daisy };

         foreach (var e in pets.DefaultIfEmpty()) {
            Console.WriteLine("Name = {0} ", e.Name);
         }

         Console.WriteLine("\nPress any key to continue.");
         Console.ReadKey();
      }

      class Pet {
         public string Name { get; set; }
         public int Age { get; set; }
      }
   }
}