using System;

namespace NullableValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Explicitly init nullable date
            //var today = new Nullable<DateTime>(DateTime.Today);

            // Use C# shorthand and implicit conversion
            DateTime? today = DateTime.Today;
            //Console.WriteLine("Value: {0}", today.Value);
            Console.WriteLine("Value: {0}", (DateTime)today);
            Console.WriteLine("Has Value: {0}", today.HasValue);

            // Check type of NVT
            Console.WriteLine("\nDateTime?.GetType: {0}", today.GetType());

            // Boxing
            Console.WriteLine("\nBoxing:");
            object boxed = today;
            DateTime date = (DateTime)boxed;
            Console.WriteLine(date);

            // Null and comparison
            Console.WriteLine("\nPress Enter to set to null");
            Console.ReadLine();
            today = null;
            Console.WriteLine("Has Value: {0}", today != null);
            Console.WriteLine("Is Today: {0}", today == DateTime.Today);

            // Try 'as' operator
            object data = today;
            var id = data as Guid?;
            Console.WriteLine("\nToday is a Guid: {0}", id != null);
        }
    }
}
