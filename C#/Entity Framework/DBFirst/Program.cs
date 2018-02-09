using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DemoEntities E = new DemoEntities())
            {
                var employee = E.Employee.ToList();

                foreach (Employee e in employee)
                {
                    Console.WriteLine($"EmpID: {e.Id} EmpName: {e.FirstName}");
                }

                Console.ReadKey();

            }
        }
    }
}
