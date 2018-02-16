using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t = new Task(() =>
            {
                Console.WriteLine("Press any key to disarm, with 5 sec");
                bool canceled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(canceled ? "disarm" : "?");
            },token);

            t.Start();

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Main Thread Finished");
            Console.ReadKey();
        }
 
    }
}