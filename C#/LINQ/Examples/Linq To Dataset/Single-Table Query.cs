using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToDataset {
   class SingleTable {
      static void Main(string[] args) {
         string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSQLDBConnectionString"].ToString();

         string sqlSelect = "SELECT * FROM Department;";

         // Create the data adapter to retrieve data from the database
         SqlDataAdapter da = new SqlDataAdapter(sqlSelect, connectString);

         // Create table mappings
         da.TableMappings.Add("Table", "Department");           

         // Create and fill the DataSet
         DataSet ds = new DataSet();
         da.Fill(ds);

         DataTable department = ds.Tables["Department"];            

         var query = from d in department.AsEnumerable()                        
         select new {
            DepartmentId = d.Field<int>("DepartmentId"),
            DepartmentName = d.Field<string>("Name")
         };

         foreach (var q in query) {
            Console.WriteLine("Department Id = {0} , Name = {1}",
               q.DepartmentId, q.DepartmentName);
         }

         Console.WriteLine("\nPress any key to continue.");
         Console.ReadKey();
      }
   }
}