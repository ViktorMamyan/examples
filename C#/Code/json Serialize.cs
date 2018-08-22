List<Clients> CL = new List<Clients>();

//Deserialize List Of Objects
string Content = System.IO.File.ReadAllText("Clients.db", Encoding.UTF8);
if (!String.IsNullOrEmpty(Content))
{
	CL = JsonConvert.DeserializeObject<List<Clients>>(Content);    
}

//Serialize List Of Objects
string json = JsonConvert.SerializeObject(CL, Formatting.Indented);
System.IO.File.WriteAllText(@"Clients.db", json, Encoding.UTF8);