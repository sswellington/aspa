using Aspa.Html.Constants;
using Aspa.Html.Layout;
using static Aspa.Html.Layout.Service;
using Logger = Aspa.Shared.Logger.Service;

namespace Aspa;

internal static class Program
{
    private static void Main()
    {
        Logger logger = new();
        logger.Information("Page: index (start)");
        Model index = new(Minified: false);
        
        string filePath = FileConstant.Combine();
        string html = Render(index);
        
        File.WriteAllText(filePath, html);
        logger.Information("Page: index (complete)");
        logger.Export();
    }
}