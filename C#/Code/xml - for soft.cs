//check for object not set
fill = ((c.Attribute("fill") == null) ? null : c.Attribute("fill").Value)

--------------------------------------------------------------

//get status

string xmlData = File.ReadAllText(xmlFilePath);
var xml = XDocument.Parse(xmlData);
var query = from c in xml.Root.Descendants("status")
			select new
			{
				code = c.Attribute("code").Value,
				V = c.Value
			};

foreach (var item in query)
{
	richTextBox1.Text += item.code + "  | " + item.V + "\r\n";
}

--------------------------------------------------------------

//get currency
string xmlData = File.ReadAllText(xmlFilePath);
XDocument xml = XDocument.Parse(xmlData);

var query = from c in xml.Root.Descendants("currency")
			select new
			{
				key = c.Attribute("key").Value,
				name = c.Attribute("name").Value,
				nameLat = c.Attribute("nameLat").Value,
				code = c.Attribute("code").Value,
				//currency = c.Value
			};

foreach (var item in query)
{
	richTextBox1.Text += item.ToString() + "\r\n";
}

--------------------------------------------------------------

//get default currency
string xmlData = File.ReadAllText(xmlFilePath);
XDocument xml = XDocument.Parse(xmlData);

var query = from c in xml.Root.Descendants("defaultCurrency")
			select new
			{
				currency = c.Attribute("currency").Value
				//currency = c.Value
			};

foreach (var item in query)
{
	richTextBox1.Text += item.ToString() + "\r\n";
}

--------------------------------------------------------------

//get country
string xmlData = File.ReadAllText(xmlFilePath);
XDocument xml = XDocument.Parse(xmlData);

var query = from c in xml.Root.Descendants("country")
			select new
			{
				key = c.Attribute("key").Value,
				name = c.Attribute("name").Value,
				nameLat = c.Attribute("nameLat").Value,
				code = c.Attribute("code").Value
				//currency = c.Value
			};

foreach (var item in query)
{
	richTextBox1.Text += item.ToString() + "\r\n";
}

--------------------------------------------------------------

//get service
string xmlData = File.ReadAllText(xmlFilePath);
XDocument xml = XDocument.Parse(xmlData);

var query = from c in xml.Root.Descendants("service")
			select new
			{
				countryKey = c.Attribute("countryKey").Value,
				name = c.Attribute("name").Value,
				key = c.Attribute("key").Value
				//currency = c.Value
			};

foreach (var item in query)
{
	richTextBox1.Text += item.ToString() + "\r\n";
}

--------------------------------------------------------------

//get rateGroup
string xmlData = File.ReadAllText(xmlFilePath);
XDocument xml = XDocument.Parse(xmlData);

var query = from c in xml.Root.Descendants("rateGroup")
			select new
			{
				serviceKey = c.Attribute("serviceKey").Value
				//currency = c.Value
			};

foreach (var item in query)
{
	richTextBox1.Text += item.ToString() + "\r\n";
}

--------------------------------------------------------------

//filtered rateGroup
string xmlData = File.ReadAllText(xmlFilePath);
XDocument xml = XDocument.Parse(xmlData);

var query = from c in xml.Root.Descendants("rateGroup")
			where c.Attribute("serviceKey").Value.Equals("8473")
			select c;
			//select new
			//{
			//    per = c.Attribute("per").Value
			//    //@group = c.Attribute("group").Value
			//    //value = c.Attribute("value").Value,
			//    //fill = c.Attribute("fill").Value
				
			//    //currency = c.Value
			//};

XDocument xml2 = XDocument.Parse(query.ForEachToString());
var query2 = from c in xml2.Root.Descendants("rate")
			 select new
			 {
				 per = c.Attribute("per").Value,
				 @group = c.Attribute("group").Value,
				 value = c.Attribute("value").Value
				 //fill = c.Attribute("fill").Value

				 //currency = c.Value
			 };

foreach (var item in query2)
{
	richTextBox1.Text += item.ToString() + "\r\n";
}

--------------------------------------------------------------

//rate
string xmlData = File.ReadAllText(xmlFilePath);
XDocument xml = XDocument.Parse(xmlData);

var query = from c in xml.Root.Descendants("rate")
			select new
			{
				per = ((c.Attribute("per") == null) ? null : c.Attribute("per").Value),
				@group = ((c.Attribute("group") == null) ? null : c.Attribute("group").Value),
				value = ((c.Attribute("value") == null) ? null : c.Attribute("value").Value),
				fill = ((c.Attribute("fill") == null) ? null : c.Attribute("fill").Value)

				//currency = c.Value
			};

foreach (var item in query)
{
	richTextBox1.Text += item.ToString() + "\r\n";
}