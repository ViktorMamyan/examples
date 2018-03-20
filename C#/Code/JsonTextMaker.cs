using ExtensionMethods;
using Newtonsoft.Json;
using System.Collections.Generic;

//Install-Package Newtonsoft.Json

namespace JsonMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create List of Class
            List<Person> people = new List<Person>{
                   new Person{ID = 1, FirstName = "Scott", LastName = "Gurthie"},
                   new Person{ID = 2, FirstName = "Bill", LastName = "Gates"}
                   };

            //Convert to JSON string
            string jsonString = people.ToJSON();

            System.Console.WriteLine(jsonString);
        }

        //Custom Class
        private class Person
        {
            public int ID { get; internal set; }
            public string FirstName { get; internal set; }
            public string LastName { get; internal set; }
        }
    }
}

//Extension Method
namespace ExtensionMethods
{
    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}