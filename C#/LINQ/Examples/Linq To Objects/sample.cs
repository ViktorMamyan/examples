using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQtoObjects {
   class Program {
      static void Main(string[] args) {
         string[] tools = { "Tablesaw", "Bandsaw", "Planer", "Jointer", "Drill", "Sander" };
         var list = from t in tools select t;

         StringBuilder sb = new StringBuilder();

         foreach (string s in list) {
            sb.Append(s + Environment.NewLine);
         }
		 
         Console.WriteLine(sb.ToString(), "Tools");
         Console.ReadLine();
      }
   }
}