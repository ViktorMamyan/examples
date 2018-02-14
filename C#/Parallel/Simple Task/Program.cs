using System;
using System.Threading.Tasks;

namespace TaskCode
{
    class Program
    {

        static void Write(object o)
        {
            int i = 1000;

            while (i-- > 0)
            {
                Console.Write(o);
            }  
        }

        static int TextLenght(object o)
        {
            Console.WriteLine("\nTask with id {0}", Task.CurrentId);
            return o.ToString().Length;
        }
    
        static void Main(string[] args)
        {
            //Task.Factory.StartNew(() => Write(123));

            //Task t = new Task(Write, "Hello");
            //t.Start();

            string text1 = "testing";
            string text2 = "this";

            var task1 = new Task<int>(TextLenght, text1);
            task1.Start();

            Task<int> task2 = Task.Factory.StartNew<int>(TextLenght, text2);

            Console.WriteLine("T1 lenght" + task1.Result);
            Console.WriteLine("T2 lenght" + task2.Result);

            Console.WriteLine("Main Thread Finished");
            Console.ReadKey();
        }
 
    }
}