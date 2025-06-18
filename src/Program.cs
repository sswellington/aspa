using Aspa.Html.Constants;
using Aspa.Html.Layout;
using Layout = Aspa.Html.Layout.Service;
using Logger = Aspa.Shared.Logger.Service;

namespace Aspa;

internal static class Program
{
    private static void Main()
    {
        Logger logger = new();
        Model model = new();
        Layout layout = new(model);
        
        string filePath = FileConstant.Combine();
        string html = layout.ToHtml;
        
        File.WriteAllText(filePath, html);
        logger.Information($"Page: {model.Head}");
        logger.Export();
    }
}