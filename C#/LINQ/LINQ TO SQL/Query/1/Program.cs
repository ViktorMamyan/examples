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
            LTSQLDataContext context = new LTSQLDataContext();

            IEnumerable<Person> result = from person in context.Persons
                                         where person.FirstName == "Ross"
                                         select person;

            foreach (var p in result)
            {
                Console.WriteLine("{0} {1}", p.FirstName,p.LastName);
            }


            Console.ReadKey();
        }
    }
}