internal static DataTable ToDataTable<T>(this IList<T> data)
{
	PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
	DataTable dt = new DataTable();
	for (int i = 0; i <= properties.Count - 1; i++)
	{
		PropertyDescriptor property = properties[i];
		dt.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
	}
	object[] values = new object[properties.Count - 1 + 1];
	foreach (T item in data)
	{
		for (int i = 0; i <= values.Length - 1; i++)
			values[i] = properties[i].GetValue(item);
		dt.Rows.Add(values);
	}
	return dt;
}