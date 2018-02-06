using System;
using System.Collections.Generic;
using System.Linq;

namespace Operators {
   class SequenceEqual {
      static void Main(string[] args) {
         Pet barley = new Pet() { Name = "Barley", Age = 4 };
         Pet boots = new Pet() { Name = "Boots", Age = 1 };
         Pet whiskers = new Pet() { Name = "Whiskers", Age = 6 };

         List<Pet> pets1 = new List<Pet>() { barley, boots };
         List<Pet> pets2 = new List<Pet>() { barley, boots };
         List<Pet> pets3 = new List<Pet>() { barley, boots, whiskers };

         bool equal = pets1.SequenceEqual(pets2);
         bool equal3 = pets1.SequenceEqual(pets3);

         Console.WriteLine("The lists pets1 and pets2 {0} equal.", equal ? "are" :"are not");
         Console.WriteLine("The lists pets1 and pets3 {0} equal.", equal3 ? "are" :"are not");

         Console.WriteLine("\nPress any key to continue.");
         Console.ReadKey();
      }

      class Pet {
         public string Name { get; set; }
         public int Age { get; set; }
      }
   }
}