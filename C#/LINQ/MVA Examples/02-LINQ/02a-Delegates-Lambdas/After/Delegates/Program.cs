using System;

namespace Delegates
{
    // Define a delegate that accepts two integers and returns an integer
    public delegate int IntDel(int a, int b);
    
    class Program
    {
        static void Main(string[] args)
        {
            // Write code in Main that initializes and invokes the delegate
            //IntDel del = new IntDel(Add); // Explicit del init
            IntDel del = Add;

            //int result = del.Invoke(1, 2); // Explicit invocation
            int result = del(1, 2);
            Console.WriteLine("Add result: {0}", result);
        }

        // Define a static Add method that matches the delegate definition
        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
