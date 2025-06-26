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
        const string name = "Wellington Silva";
        
        #region  Index
        logger.Information("Page: index (start)");
        Syntax.Heading(name, LevelTag.Is1);
        Syntax.Heading("Software Developer | .NET | SQL Server | Python", LevelTag.Is2);
        
        Model index = new
        (
            Minified: false,
            Title: name,
            Main: Syntax.ToString()
        );
        
        string indexInHtml = Render(index);
        logger.Information("Page: index (complete)");
        #endregion
        
        logger.Information("save in html (start)");
        string filePath = FilePath.Combine();
        File.WriteAllText(filePath, indexInHtml);
        logger.Information("save in html (start)");
        
        logger.Export();
    }
}