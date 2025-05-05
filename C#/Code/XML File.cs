XML File

<Employees>
  <Employee>
    <ID>1</ID>
    <Name>John</Name>
  </Employee>
  <Employee>
    <ID>2</ID>
    <Name>Jane</Name>
  </Employee>
</Employees>


Read XML into DataTable

using System.Data;

DataSet ds = new DataSet();
ds.ReadXml("employees.xml");
DataTable dt = ds.Tables[0];


Write DataTable to XML

dt.WriteXml("output.xml", XmlWriteMode.WriteSchema);


--------------------------------------------------------------------
Read and Write XML Using XmlDocument

using System.Xml;

XmlDocument doc = new XmlDocument();
doc.Load("employees.xml");

XmlNodeList nodes = doc.SelectNodes("//Employee");
foreach (XmlNode node in nodes)
{
    string id = node["ID"]?.InnerText;
    string name = node["Name"]?.InnerText;
    Console.WriteLine($"ID: {id}, Name: {name}");
}






XmlDocument doc = new XmlDocument();

XmlElement root = doc.CreateElement("Employees");
doc.AppendChild(root);

XmlElement emp = doc.CreateElement("Employee");
XmlElement id = doc.CreateElement("ID");
id.InnerText = "3";
XmlElement name = doc.CreateElement("Name");
name.InnerText = "Alice";

emp.AppendChild(id);
emp.AppendChild(name);
root.AppendChild(emp);

doc.Save("new_employees.xml");