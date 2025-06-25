using System.Text;
using Aspa.Html.Constants;

namespace Aspa.Html.Utils;

public static class Syntax
{
    private static StringBuilder _main = new StringBuilder();
    
    private static void Base(string text, char tag, TagLevel level = TagLevel.None)
    {
        if (level == TagLevel.None)
        {
            _main.AppendLine($"<{tag}> {text} </{tag}>");
            return;
        }
        
        string tagWithLevel = tag + ((int)level).ToString();
        _main.AppendLine($"<{tagWithLevel}> {text} </{tagWithLevel}>");
    }
    
    public static void Heading(string heading, TagLevel level = TagLevel.Is6) 
    {
        Base(text: heading, tag: TagConstant.Heading, level);
    }

    public static void Paragraph(string paragraph)
    {
        Base(paragraph, tag: TagConstant.Paragraph);
    }

    public static string ToMain()
    {
        return _main.ToString();
    }
}