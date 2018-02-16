using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var planned = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var emergence = new CancellationTokenSource();

            var paranoid = CancellationTokenSource
                .CreateLinkedTokenSource(
                planned.Token, preventative.Token, emergence.Token);

            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.WriteLine(i++);
                    Thread.Sleep(1000);
                }
            },paranoid.Token);

            Console.ReadKey();
            emergence.Cancel();

            Console.WriteLine("Main Thread Finished");
            Console.ReadKey();
        }
 
    }
}