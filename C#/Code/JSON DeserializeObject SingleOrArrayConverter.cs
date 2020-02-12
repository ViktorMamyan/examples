using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Results
{
	public Results()
	{
		VehicleTypes = new List<VehicleTypes>();
	}
	
	public string Country { get; set; }

	[JsonConverter(typeof(SingleOrArrayConverter<VehicleTypes>))]
	public List<VehicleTypes> VehicleTypes { get; set; }
}

public class VehicleTypes
{
	public bool IsPrimary { get; set; }
	public string Name { get; set; }
}

public class SingleOrArrayConverter<T> : JsonConverter
{
	public override bool CanConvert(Type objecType)
	{
		return (objecType == typeof(List<T>));
	}

	public override object ReadJson(JsonReader reader, Type objecType, object existingValue,
		JsonSerializer serializer)
	{
		JToken token = JToken.Load(reader);
		if (token.Type == JTokenType.Array)
		{
			return token.ToObject<List<T>>();
		}
		return new List<T> { token.ToObject<T>() };
	}

	public override bool CanWrite
	{
		get { return false; }
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		throw new NotImplementedException();
	}
}