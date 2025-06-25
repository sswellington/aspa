using Aspa.Html.Constants;
using Aspa.Html.Layout;
using Aspa.Html.Utils;
using static Aspa.Html.Layout.Service;
using Logger = Aspa.Shared.Logger.Service;

namespace Aspa;

internal static class Program
{
    private static void Main()
    {
        Logger logger = new();
        logger.Information("Page: index (start)");

        Syntax.Heading("h1", TagLevel.Is1);
        Syntax.Heading("h2", TagLevel.Is2);
        Syntax.Heading("h3", TagLevel.Is3);
        Syntax.Heading("h4", TagLevel.Is4);
        Syntax.Heading("h5", TagLevel.Is5);
        Syntax.Heading("h6");
        Syntax.Paragraph("Software Developer | .NET | SQL Server | Python");
        
        Model index = new
        (
            Minified: false,
            Title: "aspa",
            Main: Syntax.ToMain()
        );
        
        string filePath = FileConstant.Combine();
        string html = Render(index);
        
        File.WriteAllText(filePath, html);
        logger.Information("Page: index (complete)");
        logger.Export();
    }
}