using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoDataset {
   class Program {
      static void Main(string[] args) {
         string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSQLDBConnectionString"].ToString();

         string sqlSelect = "SELECT * FROM Department;" + "SELECT * FROM Employee;";

         // Create the data adapter to retrieve data from the database
         SqlDataAdapter da = new SqlDataAdapter(sqlSelect, connectString);
        
         // Create table mappings
         da.TableMappings.Add("Table", "Department");
         da.TableMappings.Add("Table1", "Employee");

         // Create and fill the DataSet
         DataSet ds = new DataSet();
         da.Fill(ds);

         DataRelation dr = ds.Relations.Add("FK_Employee_Department",
                           ds.Tables["Department"].Columns["DepartmentId"],
                           ds.Tables["Employee"].Columns["DepartmentId"]);

         DataTable department = ds.Tables["Department"];
         DataTable employee = ds.Tables["Employee"];

         var query = from d in department.AsEnumerable()
                     join e in employee.AsEnumerable()
                     on d.Field<int>("DepartmentId") equals
                     e.Field<int>("DepartmentId")                        
                     select new {
                        EmployeeId = e.Field<int>("EmployeeId"),
                        Name = e.Field<string>("Name"),                            
                        DepartmentId = d.Field<int>("DepartmentId"),                            
                        DepartmentName = d.Field<string>("Name")
                     };

         foreach (var q in query) {
            Console.WriteLine("Employee Id = {0} , Name = {1} , Department Name = {2}",
               q.EmployeeId, q.Name, q.DepartmentName);
         }

         Console.WriteLine("\nPress any key to continue.");
         Console.ReadKey();
      }
   }
}