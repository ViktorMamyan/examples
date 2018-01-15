using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Xml.Linq;
using System.Configuration;

[DataContract]
public class Car
{
    [DataMember(Order=1,Name="ՀՀ")]
    public int ID { get; set; }

    [DataMember(Order = 2)]
    public string Vendor { get; set; }

    [DataMember(Order = 3)]
    public string Model { get; set; }

    [DataMember(Order = 4)]
    public int Year { get; set; }
}

namespace Server
{

    [ServiceContract(Name="CarList")]
    public interface iCar
    {

        [OperationContract]
        void SetCar(Car car);

        [OperationContract]
        Car GetCar(int id);
    
    }

}

namespace Server
{

    public class WcfService : iCar
    {
        public void SetCar(Car car)
        {
            var file = "cars.xml"; //ConfigurationManager.AppSettings["filecar"];

            var doc = XDocument.Load(file);
            doc.Root.Add(new XElement("Car", new XAttribute("ID", car.ID)
                                            , new XAttribute("Vendor", car.Vendor)
                                            , new XAttribute("Model", car.Model)
                                            , new XAttribute("Year", car.Year)));

            doc.Save(file);

        }

        public Car GetCar(int id)
        {
            var file = "cars.xml"; //ConfigurationManager.AppSettings["filecar"];
            var result = new Car();
            var doc = XDocument.Load(file);

            var element = doc.Descendants("Car").FirstOrDefault(x => x.Attribute("ID").Value == id.ToString());

            result.ID = int.Parse(element.Attribute("ID").Value);
            result.Vendor = element.Attribute("Vendor").Value;
            result.Model = element.Attribute("Model").Value;
            result.Year = int.Parse(element.Attribute("Year").Value);

            return result;
        }
    }

}