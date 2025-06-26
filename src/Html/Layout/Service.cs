using Aspa.Html.Constants;
using Aspa.Shared;
using static Aspa.Html.Utils.Semantic;

namespace Aspa.Html.Layout;

public abstract record Service
{
    public static string Render(Model model)
    {
        string title = AddValueToTag(string.Empty, Tag.Title);
        string newTitle = AddValueToTag(model.Title, Tag.Title);
        
        string main = AddValueToTag(string.Empty, Tag.Main);
        string newMain = AddValueToTagLine(model.Main, Tag.Main);
        
        string html = Template.NewCss
            .Replace(title, newTitle)
            .Replace(main, newMain);
        
        return model.Minified ? Minify.Get(html) : html;
    }
}