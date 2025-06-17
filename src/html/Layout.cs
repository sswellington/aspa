using Aspa.html.Constants;
using Aspa.shared;

namespace Aspa.html;

public class Layout
{
    private readonly Model _model;
    private static string Template => LayoutConstant.Template;
    public readonly string ToHtml;
    
    public Layout(Model model)
    {
        _model = model;
        ToHtml = Render();
        if (_model.Minified) 
            ToHtml = Minify.Get(Template);
    }
    
    private string Render()
    {
        string title = $"<title> {_model.Title} </title>"; 
        string body = $"<body> \n    {_model.Body} \n  </body>";
        return Template
            .Replace("<title></title>", title)
            .Replace("<body></body>", body);
    }
}