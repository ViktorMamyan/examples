using DataAccess;
using System;
using System.Linq;

namespace LINQTOSQLConsoleApp {
   public class LinqToEntityModel {
      static void Main(string[] args) {
         using (LinqToSQLDBEntities context = new LinqToSQLDBEntities()) {
            //Get the List of Departments from Database
            var departmentList = from d in context.Departments
            select d;

            foreach (var dept in departmentList) {
               Console.WriteLine("Department Id = {0} , Department Name = {1}",
                  dept.DepartmentId, dept.Name);
            }

            //Add new Department
            DataAccess.Department department = new DataAccess.Department();
            department.Name = "Support";

            context.Departments.Add(department);
            context.SaveChanges();

            Console.WriteLine("Department Name = Support is inserted in Database");

            //Update existing Department
            DataAccess.Department updateDepartment = context.Departments.FirstOrDefault(d ⇒d.DepartmentId == 1);
            updateDepartment.Name = "Account updated";
            context.SaveChanges();

            Console.WriteLine("Department Name = Account is updated in Database");

            //Delete existing Department
            DataAccess.Department deleteDepartment = context.Departments.FirstOrDefault(d ⇒d.DepartmentId == 3);
            context.Departments.Remove(deleteDepartment);
            context.SaveChanges();

            Console.WriteLine("Department Name = Pre-Sales is deleted in Database");

            //Get the Updated List of Departments from Database
            departmentList = from d in context.Departments
            select d;

            foreach (var dept in departmentList) {
               Console.WriteLine("Department Id = {0} , Department Name = {1}",
                  dept.DepartmentId, dept.Name);
            }
         }

         Console.WriteLine("\nPress any key to continue.");
         Console.ReadKey();
      }
   }
}