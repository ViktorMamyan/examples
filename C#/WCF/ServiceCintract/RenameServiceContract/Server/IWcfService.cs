using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{

    [ServiceContract(Name="Գումար")]
    public interface iSum
    {

        [OperationContract]
        int GetSum(int x,int y);
    
    }

}

namespace Server
{

    public class WcfService : iSum
    {

        public int GetSum(int x, int y)
        {
            Console.WriteLine("SUM {0} + {1} = {2}", x, y, x + y);
            return x + y;
        }
    }

}