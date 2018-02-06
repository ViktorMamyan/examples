using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {

            var schedule = GetDates();
            var areYouAvailable = new DateTime(11, 7, 5);

            //Linq query
            var busy = from d in schedule
                       where d == areYouAvailable
                       select d;
            foreach (var busyDate in busy)
            {
                Console.WriteLine("Sorry, but I am busy on {0:dd/MM/yyyy}", busyDate);
            }


            //where in loop part
            foreach (var busyDate in schedule.Where(d => d == areYouAvailable))
            {
                Console.WriteLine("Sorry, but I am busy on {0:dd/MM/yyyy}", busyDate);
            }

            var count = (from d in schedule
                       where d == areYouAvailable
                       select d).Count();

            Console.WriteLine("Busy days: " + count);

            Console.ReadKey();
        }

        private static List<DateTime> GetDates()
        {
            return new List<DateTime>
                {
                new DateTime(11, 1, 1),
                new DateTime(11, 2, 5),
                new DateTime(11, 3, 3),
                new DateTime(11, 1, 3),
                new DateTime(11, 1, 2),
                new DateTime(11, 5, 4),
                new DateTime(11, 2, 2),
                new DateTime(11, 7, 5),
                new DateTime(11, 6, 30),
                new DateTime(11, 10, 14),
                new DateTime(11, 11, 22),
                new DateTime(11, 12, 1),
                new DateTime(11, 5, 22),
                new DateTime(11, 6, 7),
                new DateTime(11, 1, 4)
                };
        }

    }
}