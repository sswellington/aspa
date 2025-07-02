using System.Text;
using Aspa.Html.Constants;

namespace Aspa.Html.Utils;

public static class Chevron
{
	private static string OpeningTags(string tag)
	{
		return new StringBuilder()
			.Append('<')
			.Append(tag)
			.Append('>')
			.ToString();
	}

	private static string ClosingTags(string tag)
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
			.Append(OpeningTags(tag))
			.Append(value)
			.Append(ClosingTags(tag))
			.ToString();
	}
	
	public static string AddValueToTag(string value, string tag, string indentation)
	{
		return new StringBuilder()
			.Append(Indentation.Main)
			.Append(indentation)
			.Append(OpeningTags(tag))
			.Append(value)
			.Append(ClosingTags(tag))
			.ToString();
	}

	public static string AddValueToTagLine(string value, string tag)
	{
		return new StringBuilder()
			.AppendLine(OpeningTags(tag))
			.AppendLine(value)
			.Append(Indentation.Main) 
			.Append(ClosingTags(tag))
			.ToString();
	}
}