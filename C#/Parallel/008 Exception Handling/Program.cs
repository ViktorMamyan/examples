using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Factory.StartNew(() =>
            {
                throw new InvalidOperationException("Exception From t");
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("Can't access") {Source = "t2"};
            });

            try
            {
                Task.WaitAll(t, t2);
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    Console.WriteLine("Exception " + e.GetType() + "From " + e.Source);
                }
            }

            Console.WriteLine("Main Thread Finished");
            Console.ReadKey();
        }
 
    }
}