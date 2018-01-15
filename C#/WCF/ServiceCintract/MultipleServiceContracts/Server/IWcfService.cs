using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{

    [ServiceContract]
    public interface iSum
    {

        [OperationContract]
        int GetSum(int x,int y);
    
    }

    [ServiceContract]
    public interface iMultiplicate
    {

        [OperationContract]
        int GetM(int x, int y);

    }

}

namespace Server
{

    public class WcfService : iSum, iMultiplicate
    {

        public int GetSum(int x, int y)
        {
            Console.WriteLine("SUM {0} + {1} = {2}", x, y, x + y);
            return x + y;
        }

        public int GetM(int x, int y)
        {
            Console.WriteLine("MUL {0} * {1} = {2}", x, y, x * y);
            return x * y;
        }
    }

}