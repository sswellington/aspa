using Aspa.Html.Constants;

namespace Aspa.Html.Layout;

public record Model
(
    bool Minified = true,
    string Title = LoremIpsum.Title,
    string Main = LoremIpsum.Main
);