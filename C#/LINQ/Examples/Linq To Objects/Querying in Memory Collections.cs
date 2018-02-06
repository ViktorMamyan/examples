using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQtoObjects {
   class Department {
      public int DepartmentId { get; set; }
      public string Name { get; set; }
   }

   class LinqToObjects {
      static void Main(string[] args) {
         List<Department> departments = new List<Department>();
			
         departments.Add(new Department { DepartmentId = 1, Name = "Account" });
         departments.Add(new Department { DepartmentId = 2, Name = "Sales" });
         departments.Add(new Department { DepartmentId = 3, Name = "Marketing" });

         var departmentList = from d in departments
                              select d;

         foreach (var dept in departmentList) {
            Console.WriteLine("Department Id = {0} , Department Name = {1}",
               dept.DepartmentId, dept.Name);
         }
		 
         Console.WriteLine("\nPress any key to continue.");
         Console.ReadKey();
      }
   }
}