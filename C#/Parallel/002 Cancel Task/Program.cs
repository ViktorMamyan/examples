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
                    int i = 0;
                    while (true)
                    {
                        if (token.IsCancellationRequested)
                        {
                            break;

                            //or
                            //throw new OperationCanceledException();
                        }
                        else
                        {
                            Console.WriteLine("t1 " + i++ + "\t");
                        }
                    }
                },token);
            t.Start();

            var t2 = new Task(() =>
                {
                    var i = 0;
                    while (true)
                    {
                        token.ThrowIfCancellationRequested();
                        Console.WriteLine("t2 " + i++ + "\t");
                    }
                },token);
            t2.Start();

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Main Thread Finished");
            Console.ReadKey();
        }
 
    }
}