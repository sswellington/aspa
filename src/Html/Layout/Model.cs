using Aspa.Html.Constants;

namespace Aspa.Html.Layout;

public class Model
(
    bool minified = true,
    string title = LoremIpsum.Title,
    string main = LoremIpsum.Main
)
{
    public bool Minified = minified;
    public string Title = title;
    public string Main = main;
}
