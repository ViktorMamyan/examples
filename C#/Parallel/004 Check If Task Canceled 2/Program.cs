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

            token.Register(() =>
                {
                    Console.WriteLine("Cancel Requested");
                });

            var t = new Task(() =>
                {
                    int i = 0;
                    while (true)
                    {
                        token.ThrowIfCancellationRequested();
                        Console.WriteLine("t2 " + i++ + "\t");
                    }
                },token);
            t.Start();

            Task.Factory.StartNew(() =>
                {
                    token.WaitHandle.WaitOne();
                    Console.WriteLine("Cancel Requested Handeled");
                });

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Main Thread Finished");
            Console.ReadKey();
        }
 
    }
}