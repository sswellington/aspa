using Aspa.Shared;

namespace Aspa.Html.Layout;

public class Service
{
    private readonly Model _model;
    public readonly string ToHtml;
    
    public Service(Model model)
    {
        _model = model;
        ToHtml = Render();
        if (_model.Minified) 
            ToHtml = Minify.Get(Constant.Template);
    }
    
    private string Render()
    {
        string title = $"<title> {_model.Head} </title>"; 
        string body = $"<body> \n    {_model.Body} \n  </body>";
        return Constant.Template
            .Replace("<title></title>", title)
            .Replace("<body></body>", body);
    }
}