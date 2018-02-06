using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operators {
   class Program {
      static void Main(string[] args) {
         string[] names = { "Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow", 
                       "Hedlund, Magnus", "Ito, Shu" };
         Random random = new Random(DateTime.Now.Millisecond);

         string name = names.ElementAt(random.Next(0, names.Length));

         Console.WriteLine("The name chosen at random is '{0}'.", name);
         Console.ReadLine();
      }
   }
}