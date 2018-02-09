using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFromDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Model context = new Model())
            {
                var Emp = context.Employee.ToList();

                foreach (var item in Emp)
                {
                    Console.WriteLine(item.FirstName);
                }

                Console.ReadKey();
            }

        }

    }
}