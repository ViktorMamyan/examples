using System;
using System.Linq;

namespace LINQtoSQL {
   class LinqToSQLCRUD {
      static void Main(string[] args) {
         string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSQLDBConnectionString"].ToString();

         LinqToSQLDataContext db = new LinqToSQLDataContext(connectString);

         //Get Employee for update
         Employee employee = db.Employees.FirstOrDefault(e =>e.Name.Equals("Michael"));

         employee.Name = "George Michael";
         employee.Email = "yourname@companyname.com";
         employee.ContactNo = "99999999";
         employee.DepartmentId = 2;
         employee.Address = "Michael George - UK";

         //Save changes to Database.
         db.SubmitChanges();

         //Get Updated Employee            
         Employee updatedEmployee = db.Employees.FirstOrDefault(e ⇒e.Name.Equals("George Michael"));

         Console.WriteLine("Employee Id = {0} , Name = {1}, Email = {2}, ContactNo = {3}, Address = {4}",
                          updatedEmployee.EmployeeId, updatedEmployee.Name, updatedEmployee.Email, 
                          updatedEmployee.ContactNo, updatedEmployee.Address);

         Console.WriteLine("\nPress any key to continue.");
         Console.ReadKey();
      }
   }
}