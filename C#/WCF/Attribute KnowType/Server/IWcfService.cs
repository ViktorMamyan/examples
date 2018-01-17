using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Xml.Linq;
using System.Configuration;
using System.Globalization;

namespace Server
{
    [KnownType(typeof(TruckCar))]
    [KnownType(typeof(PassengerCar))]
    [DataContract]
    public class Car
    {
        [DataMember(Order = 1, Name = "ՀՀ")]
        public int ID { get; set; }

        [DataMember(Order = 2)]
        public string Vendor { get; set; }

        [DataMember(Order = 3)]
        public string Model { get; set; }

        [DataMember(Order = 4)]
        public int Year { get; set; }
    }


    public class TruckCar :Car
    {
        public double Capacity { get; set; }
    }


    public class PassengerCar :Car
    {
        public int Passengers { get; set; }
     }

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

            var element = new XElement("Car", new XAttribute("ID", car.ID)
                                            , new XAttribute("Vendor", car.Vendor)
                                            , new XAttribute("Model", car.Model)
                                            , new XAttribute("Year", car.Year));

            if (car is TruckCar)
            {
                element.Add(new XAttribute("Type", "Truck"),
                    new XElement("Capacity", ((TruckCar)car).Capacity.ToString(CultureInfo.GetCultureInfo("en-US"))));
            }
            else
            {
                element.Add(new XAttribute("Type", "Passenger"),
                    new XElement("Passengers", ((PassengerCar)car).Passengers.ToString(CultureInfo.GetCultureInfo("en-US"))));            
            }

            var doc = XDocument.Load(file);
            doc.Root.Add(element);

            doc.Save(file);

        }

        public Car GetCar(int id)
        {
            var file = "cars.xml"; //ConfigurationManager.AppSettings["filecar"];
            Car result;
            
            var doc = XDocument.Load(file);

            var element = doc.Descendants("Car").FirstOrDefault(x => x.Attribute("ID").Value == id.ToString());

            var type = element.Attribute("Type").Value;

            switch (type)
            {
                case "Truck":
                    result =new TruckCar();
                    ((TruckCar)result).Capacity = double.Parse(element.Element("Capacity").Value
                        ,CultureInfo.GetCultureInfo("en-US"));
                    break;
                case "Passenger":
                    result =new PassengerCar();
                    ((PassengerCar)result).Passengers = int.Parse(element.Element("Passengers").Value);
                    break;

                default:
                    result = new Car();
                    break;
            }

            result.ID = int.Parse(element.Attribute("ID").Value);
            result.Vendor = element.Attribute("Vendor").Value;
            result.Model = element.Attribute("Model").Value;
            result.Year = int.Parse(element.Attribute("Year").Value);

            return result;
        }
    }

}