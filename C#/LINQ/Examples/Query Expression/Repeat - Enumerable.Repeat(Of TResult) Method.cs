using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operators {
   class Program {
      static void Main(string[] args) {
         IEnumerable<string> strings = Enumerable.Repeat("I like programming.", 3);

         foreach (String str in strings) {
            Console.WriteLine(str);
         }
			
         Console.ReadLine();
      }
   }
}