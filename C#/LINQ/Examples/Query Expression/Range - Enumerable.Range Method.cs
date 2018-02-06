using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operators {
   class Program {
      static void Main(string[] args) {
         // Generate a sequence of integers from 1 to 5  
         // and then select their squares.
		 
         IEnumerable<int> squares = Enumerable.Range(1, 5).Select(x => x * x);

         foreach (int num in squares) {
            Console.WriteLine(num);
         }
			
         Console.ReadLine();
      }
   }
}