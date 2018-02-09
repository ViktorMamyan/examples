using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeF context = new CodeF();
            var list = context.EmployeeInfos.ToList();

            foreach (var item in list)
            {
                Console.WriteLine(item.FirstName);
            }

            Console.WriteLine("OK");
            Console.ReadKey();
        }

    }
}