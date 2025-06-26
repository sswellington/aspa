using System.Text;
using Aspa.Html.Constants;
using Aspa.Shared;

namespace Aspa.Html.Layout;

public abstract record Service
{
    private static string TitleTag(string titleTag)
    {
        return new StringBuilder()
            .Append('<')
            .Append(Tag.Title)
            .Append('>')
            .Append(titleTag)
            .Append("</")
            .Append(Tag.Title)
            .Append('>')
            .ToString();
    }

    private static string MainTag(string mainTag)
    {
        return new StringBuilder()
            .Append('<')
            .Append(Tag.Main)
            .Append(">\n")
            .Append(mainTag)
            .Append("        </")
            .Append(Tag.Title)
            .Append('>')
            .ToString();
    }

    public static string Render(Model model)
    {
        string html = Template.NewCss
            .Replace("<title></title>", TitleTag(model.Title))
            .Replace("<main></main>", MainTag(model.Main));
        
        return model.Minified ? Minify.Get(html) : html;
    }
}