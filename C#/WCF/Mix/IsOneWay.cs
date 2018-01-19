using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

[ServiceContract()]
public interface ILogisticsService2
{
    [OperationContract(IsOneWay = true)]
    void CancelWorkOrder(int workOrderNumber);
}