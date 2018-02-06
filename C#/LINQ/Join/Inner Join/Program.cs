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
            var cars = GetCars();
            var repairs = GetRepairs();

            var carsWithRepairs = from c in cars
                                  join r in repairs
                                  on c.VIN equals r.VIN
                                  orderby c.VIN, r.Cost
                                  select new
                                  {
                                      c.VIN,
                                      c.Make,
                                      r.Desc,
                                      r.Cost
                                  };

            foreach (var item in carsWithRepairs)
            {
                Console.WriteLine("Car VIN:{0}, Make:{1}, Description:{2} Cost:{3:C}",
                item.VIN, item.Make, item.Desc, item.Cost);
            }

            Console.ReadKey();
        }

        private static List<Car> GetCars()
            {
                return new List<Car>
                    {
                        new Car {VIN = "ABC123",Make = "Ford",
                            Model = "F-250", Year = 2000},
                        new Car {VIN = "DEF123",Make = "BMW",
                        Model = "Z-3", Year = 2005},
                        new Car {VIN = "ABC456",Make = "Audi",
                        Model = "TT", Year = 2008},
                        new Car {VIN = "HIJ123",Make = "VW",
                        Model = "Bug", Year = 1956},
                        new Car {VIN = "DEF456",Make = "Ford",
                        Model = "F-150", Year = 1998}
                    };
            }

        private static List<Repair> GetRepairs()
            {
                return new List<Repair>
                    {
                        new Repair {VIN = "ABC123", Desc = "Change Oil", Cost = 29.99m},new Repair {VIN = "DEF123", Desc = "Rotate Tires", Cost =19.99m},
                        new Repair {VIN = "HIJ123", Desc = "Replace Brakes", Cost = 200},
                        new Repair {VIN = "DEF456", Desc = "Alignment", Cost = 30},
                        new Repair {VIN = "ABC123", Desc = "Fix Flat Tire", Cost = 15},
                        new Repair {VIN = "DEF123", Desc = "Fix Windshield", Cost =420},
                        new Repair {VIN = "ABC123", Desc = "Replace Wipers", Cost = 20},
                        new Repair {VIN = "HIJ123", Desc = "Replace Tires", Cost = 1000},
                        new Repair {VIN = "DEF456", Desc = "Change Oil", Cost = 30}
                    };
            }

    }

    public class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }

    public class Repair
    {
        public string VIN { get; set; }
        public string Desc { get; set; }
        public decimal Cost { get; set; }
    }

}