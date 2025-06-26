using System.Text;
using Aspa.Html.Constants;

namespace Aspa.Html.Utils;

public static class Semantic
{
	private static string Open(string tag)
	{
		return new StringBuilder()
			.Append('<')
			.Append(tag)
			.Append('>')
			.ToString();
	}

	private static string Close(string tag)
	{
		return new StringBuilder()
			.Append("</")
			.Append(tag)
			.Append('>')
			.ToString();
	}
	
	public static string AddValueToTag(string value, string tag)
	{
		return new StringBuilder()
			.Append(Open(tag))
			.Append(value)
			.Append(Close(tag))
			.ToString();
	}
	
	public static string AddValueToTag(string value, string tag, string indentation)
	{
		return new StringBuilder()
			.Append(Indentation.Main)
			.Append(indentation)
			.Append(Open(tag))
			.Append(value)
			.Append(Close(tag))
			.ToString();
	}

	public static string AddValueToTagLine(string value, string tag)
	{
		return new StringBuilder()
			.AppendLine(Open(tag))
			.AppendLine(value)
			.Append(Indentation.Main) 
			.Append(Close(tag))
			.ToString();
	}
}