using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

[ServiceContract]
interface IGreetingHandler
{
    [OperationContract(IsOneWay = true)]
    void GreetingProduced(string greeting);
}

[ServiceContract(CallbackContract =typeof(IGreetingHandler))]
interface IGreetingService
{
    [OperationContract(IsOneWay = true)]
    void RequestGreeting(string name);
}

[ServiceBehavior(InstanceContextMode =InstanceContextMode.PerSession)]
class GreetingService : IGreetingService
{
    public void RequestGreeting(string name)
    {
        Console.WriteLine("In Service.Greet");
        IGreetingHandler callbackHandler =
        OperationContext.Current.GetCallbackChannel<IGreetingHandler>();
        callbackHandler.GreetingProduced("Hello " + name);
    }
}