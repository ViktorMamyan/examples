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
                Console.WriteLine("Take 5 Sec");

                for (int i = 0; i < 5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }

                Console.WriteLine("Done");
            },token);

            t.Start();

            Task t2 = Task.Factory.StartNew(() =>
            Thread.Sleep(3000),token);

            Task.WaitAll(t,t2);

            //Task.WaitAny(t, t2);

            Console.WriteLine("Main Thread Finished");
            Console.ReadKey();
        }
 
    }
}