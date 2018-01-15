using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFApp
{

    //Interface

    [ServiceContract]
    public interface iWCF
    {
        [OperationContract]
        void iInfo();

        [OperationContract]
        string jInfo();

        [OperationContract]
        string GetIP();

        [OperationContract]
        string GetIP2();

    }

    
    // Implimentation Class

    public class WCFClass : iWCF
    {
        public void iInfo()
        {
            Console.WriteLine("OK");
        }

        public string jInfo()
        {
            return "Data from server";
        }

        // should be checked
        public string GetIP()
        {
            OperationContext context = OperationContext.Current;
            System.ServiceModel.Channels.MessageProperties properties = context.IncomingMessageProperties;
            System.ServiceModel.Channels.RemoteEndpointMessageProperty endpoint = properties[System.ServiceModel.Channels.RemoteEndpointMessageProperty.Name] as System.ServiceModel.Channels.RemoteEndpointMessageProperty;

            string address = string.Empty;

            if (properties.Keys.Contains(System.ServiceModel.Channels.HttpRequestMessageProperty.Name))
            {
                System.ServiceModel.Channels.HttpRequestMessageProperty endpointLoadBalancer = properties[System.ServiceModel.Channels.HttpRequestMessageProperty.Name] as System.ServiceModel.Channels.HttpRequestMessageProperty;
                if (endpointLoadBalancer != null && endpointLoadBalancer.Headers["X-Forwarded-For"] != null)
                    address = endpointLoadBalancer.Headers["X-Forwarded-For"];
            }

            if (string.IsNullOrEmpty(address))
            {
                address = endpoint.Address;
            }

            return address;
        }

        // should be checked
        public string GetIP2()
        {
            OperationContext oOperationContext = OperationContext.Current;
            System.ServiceModel.Channels.MessageProperties oMessageProperties = oOperationContext.IncomingMessageProperties;
            System.ServiceModel.Channels.RemoteEndpointMessageProperty oRemoteEndpointMessageProperty = (System.ServiceModel.Channels.RemoteEndpointMessageProperty)oMessageProperties[System.ServiceModel.Channels.RemoteEndpointMessageProperty.Name];

            string szAddress = oRemoteEndpointMessageProperty.Address;
            int nPort = oRemoteEndpointMessageProperty.Port;

            return "IP " + szAddress + " Port " + nPort.ToString();
        }

    }

}