using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

[ServiceContract()]
public interface ICalculatorService
{
    [OperationContract()]
    [FaultContract(typeof(string))]
    double Divide(double numerator, double denominator);
}
public class CalculatorService : ICalculatorService
{
    public double Divide(double numerator, double denominator)
    {
        if (denominator == 0.0d)
        {
            string faultDetail = "You cannot divide by zero";
            throw new FaultException<string>(faultDetail);
        }
        return numerator / denominator;
    }
}