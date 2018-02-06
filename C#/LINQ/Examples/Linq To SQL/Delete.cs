using System;
using System.Linq;

namespace LINQtoSQL {
   class LinqToSQLCRUD {
      static void Main(string[] args) {
         string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSQLDBConnectionString"].ToString();

         LinqToSQLDataContext db = newLinqToSQLDataContext(connectString);

         //Get Employee to Delete
         Employee deleteEmployee = db.Employees.FirstOrDefault(e ⇒e.Name.Equals("George Michael"));

         //Delete Employee
         db.Employees.DeleteOnSubmit(deleteEmployee);

         //Save changes to Database.
         db.SubmitChanges();

         //Get All Employee from Database
         var employeeList = db.Employees;
         foreach (Employee employee in employeeList) {
            Console.WriteLine("Employee Id = {0} , Name = {1}, Email = {2}, ContactNo = {3}",
               employee.EmployeeId, employee.Name, employee.Email, employee.ContactNo);
         }            

         Console.WriteLine("\nPress any key to continue.");
         Console.ReadKey();
      }
   }
}