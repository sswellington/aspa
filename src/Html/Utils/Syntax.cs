using System.Text;
using Aspa.Html.Constants;

namespace Aspa.Html.Utils;

public static class Syntax
{
    private readonly static StringBuilder Content = new();
    
    private static void Base(string text, string tag, LevelTag level = LevelTag.None)
    {
        const string indent = "            ";
        if (level == LevelTag.None)
        {
            Content.AppendLine($"{indent}<{tag}> {text} </{tag}>");
            return;
        }
        
        string tagWithLevel = $"{tag}{((int)level)}";
        Content.AppendLine($"{indent}<{tagWithLevel}> {text} </{tagWithLevel}>");
    }

    public static void Root(string command)
    {
        Content.AppendLine(command);
    }
    
    public static void Heading(string heading, LevelTag level = LevelTag.Is6) 
    {
        Base(text: heading, tag: Tag.Heading, level);
    }

    public static void Paragraph(string paragraph)
    {
        Base(paragraph, tag: Tag.Paragraph);
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