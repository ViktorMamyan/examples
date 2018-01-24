using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
             //  in   out
            Func<int, int> square = x => x * x;

            //  in   in   out
            Func<int,int, int> Add = (x,y) => x + y;

            Func<int, int, int> Add2 = (x, y) =>
                {
                    int r = x + y;
                    return r;
                };

            Console.WriteLine("{0} ^ {1} = {2}", 4, 2, square(4));
            Console.WriteLine("{0} + {1} = {2}", 20, 50, Add(20, 50));
            Console.WriteLine("{0} + {1} = {2}", 20, 50, Add2(20, 50));

            //void
            Action<int> W = x => Console.WriteLine(x);
            W(5000);

            Action<string> W2 = x => Console.WriteLine(x);
            W2("Hello");

            Console.ReadKey();
        }
    }
}