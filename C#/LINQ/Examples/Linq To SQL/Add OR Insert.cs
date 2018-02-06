using System;
using System.Linq;

namespace LINQtoSQL {
   class LinqToSQLCRUD {
      static void Main(string[] args) {
         string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSQLDBConnectionString"].ToString();

         LinqToSQLDataContext db = new LinqToSQLDataContext(connectString);           

         //Create new Employee
		 
         Employee newEmployee = new Employee();
         newEmployee.Name = "Michael";
         newEmployee.Email = "yourname@companyname.com";
         newEmployee.ContactNo = "343434343";
         newEmployee.DepartmentId = 3;
         newEmployee.Address = "Michael - USA";

         //Add new Employee to database
         db.Employees.InsertOnSubmit(newEmployee);

         //Save changes to Database.
         db.SubmitChanges();

         //Get new Inserted Employee            
         Employee insertedEmployee = db.Employees.FirstOrDefault(e ⇒e.Name.Equals("Michael"));

         Console.WriteLine("Employee Id = {0} , Name = {1}, Email = {2}, ContactNo = {3}, Address = {4}",
                          insertedEmployee.EmployeeId, insertedEmployee.Name, insertedEmployee.Email, 
                          insertedEmployee.ContactNo, insertedEmployee.Address);

         Console.WriteLine("\nPress any key to continue.");
         Console.ReadKey();
      }
   }
}