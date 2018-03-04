using System;

namespace Code
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new Exception("Error");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadKey();
        }
    }
}