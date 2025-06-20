using Aspa.Shared;

namespace Aspa.Html.Layout;

public abstract record Service
{
    public static string Render(Model model)
    {
        string title = $"<title> {model.Head} </title>"; 
        string body = $"<body> \n        {model.Body} \n    </body>";
        
        string html = Constant.Template
            .Replace("<title></title>", title)
            .Replace("<body></body>", body);
        
        return model.Minified ? Minify.Get(html) : html;
    }
}