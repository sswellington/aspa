using System.Text;
using Aspa.Html.Constants;
using static Aspa.Html.Utils.Semantic;

namespace Aspa.Html.Utils;

public static class Syntax
{
    private readonly static StringBuilder Content = new();

    private static void Base(string text, string tag)
    {
        Content.AppendLine(AddValueToTag(text, tag, Indentation.Unit));
    }
    
    public static void Super(string text, string tag)
    {
        Base(text, tag);
    }

    public static void Heading(string heading, HeadingLevel headingLevel = HeadingLevel.Is6)
    {
        string tag = new StringBuilder()
            .Append('h')
            .Append((int)headingLevel)
            .ToString();
        Base(heading, tag);
    }
    
    public static void Paragraph(string paragraph)
    {
        Base(paragraph, tag: "p");
    }

    public static void Clear()
    {
        Content.Clear();
    }

    public new static string ToString()
    {
        return Content.ToString();
    }
}