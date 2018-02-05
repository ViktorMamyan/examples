using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = Employee.GetAll().Select(emp => emp.EmployeeID);
            foreach (var item in query)
            {
                Console.WriteLine(item);    
            }

            Console.ReadKey();
        }
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }

        public static List<Employee> GetAll()
        {
            List<Employee> E = new List<Employee>();

            E.Add(new Employee{EmployeeID=1,FirstName="FN1"});
            E.Add(new Employee{EmployeeID=2,FirstName="FN2"});

            return E;
        }

        public Employee()
        {
            // TODO: Complete member initialization
        }
    }

}