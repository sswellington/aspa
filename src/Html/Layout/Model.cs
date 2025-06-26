using Aspa.Html.Constants;
using Aspa.Html.Utils;
using Aspa.Shared;

namespace Aspa.Html.Layout;

public class Model
{
    public bool Minified;
    public string Title;
    public string Main;

    // ReSharper disable once ConvertToPrimaryConstructor
    public Model(bool minified = true, string title = LoremIpsum.Title, string main = LoremIpsum.Main)
    {
        Minified = minified;
        Title = title;
        Main = main;
    }
    
    public string Render()
    {
        string title = Semantic.AddValueToTag(string.Empty, Tag.Title);
        string newTitle = Semantic.AddValueToTag(Title, Tag.Title);
        
        string main = Semantic.AddValueToTag(string.Empty, Tag.Main);
        string newMain = Semantic.AddValueToTagLine(Main, Tag.Main);
        
        string html = Template.NewCss
            .Replace(title, newTitle)
            .Replace(main, newMain);
        
        return Minified ? Minify.Get(html) : html;
    }
}
