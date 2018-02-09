using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ModelFContainer M = new ModelFContainer())
            {
                //dd new data
                M.EmployeeSet.Add(new Employee {FirstName="FN",LastName="LN",HireDate=new DateTime(1985,01,01) });
                M.SaveChanges();

                //get data
                var E = M.EmployeeSet.ToList();

                foreach (var item in E)
                {
                    Console.WriteLine($"EmpID: {item.Id} EmpName: {item.LastName}");
                }

            }

            Console.ReadKey();
        }

    }
}