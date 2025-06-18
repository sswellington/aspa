namespace Aspa.Html.Layout;

public record Model
(
    bool Minified = false,
    string Head = "Aspa - Home",
    string Body = "<h1> Title </h1>"
);