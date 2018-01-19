using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFCode
{

    [ServiceContract]
    public interface IXServer
    {
        //json
        [OperationContract]
        [WebGet(UriTemplate = "/json/{Name}",
                   RequestFormat=WebMessageFormat.Json,
                   ResponseFormat=WebMessageFormat.Json,
                   BodyStyle=WebMessageBodyStyle.Wrapped    //Bare
                   )]
        string RequestDataJson(string Name);

        //xml
        [OperationContract]
        [WebGet(UriTemplate = "/xml/{Name}",
           RequestFormat = WebMessageFormat.Xml,
           ResponseFormat = WebMessageFormat.Xml,
           BodyStyle = WebMessageBodyStyle.Wrapped     //Bare
           )]
        string RequestDataXml(string Name);
    }
}

namespace WCFCode
{

    [ServiceBehavior(AddressFilterMode=AddressFilterMode.Any,
                     InstanceContextMode = InstanceContextMode.PerCall,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class XServer : IXServer
    {
        public string RequestDataJson(string Name)
        {
            return Ret(Name);
        }

        public string RequestDataXml(string Name)
        {
            return Ret(Name);
        }

        private string Ret(string Name)
        {
            return "Hello " + Name;
        }
    }

}