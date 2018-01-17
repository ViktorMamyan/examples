using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFCode
{

    [ServiceContract]
    public interface IXServer
    {
        [OperationContract]
        int Divide(int val1, int val2);
    }
}

namespace WCFCode
{

    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class XServer : IXServer
    {
        public int Divide(int val1, int val2)
        {
            Console.WriteLine(this.GetHashCode().ToString());

            if (val2 == 0)
                throw new FaultException("Divided by 0");

            return val1 / val2;
        }
    }
}