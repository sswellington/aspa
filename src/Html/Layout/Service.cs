using Aspa.Html.Constants;
using Aspa.Shared;

namespace Aspa.Html.Layout;

public abstract record Service
{
    public static string Render(Model model)
    {
        string title = $"<{TagConstant.Title}>{model.Title}</{TagConstant.Title}>"; 
        string body = $"<{TagConstant.Main}>\n            {model.Main} \n        </{TagConstant.Main}>";
        
        string html = Constant.Template
            .Replace($"<{TagConstant.Title}></{TagConstant.Title}>", title)
            .Replace($"<{TagConstant.Main}></{TagConstant.Main}>", body);
        
        return model.Minified ? Minify.Get(html) : html;
    }
}