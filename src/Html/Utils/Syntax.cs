using System.Text;
using Aspa.Html.Constants;
using Aspa.Shared;
using static Aspa.Html.Utils.Chevron;

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
    
    public static string Render(string title, string main, bool minified)
    {
        string oldTitle = AddValueToTag(string.Empty, Tag.Title);
        string newTitle = AddValueToTag(title, Tag.Title);
        
        string oldMain = AddValueToTag(string.Empty, Tag.Main);
        string newMain = AddValueToTagLine(main, Tag.Main);
        
        string html = Template.NewCss()
            .Replace(oldTitle, newTitle)
            .Replace(oldMain, newMain);
        
        return minified ? Minify.Get(html) : html;
    }
}