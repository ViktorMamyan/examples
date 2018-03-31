using System.Collections.Generic;
using System.Text;

public static class Extension
{
	public static string ForEachToString<T>(this IEnumerable<T> q)
	{
		StringBuilder sb = new StringBuilder();
		foreach (T value in q)
		{
			sb.Append(value);
		}
		return sb.ToString();
	}

}