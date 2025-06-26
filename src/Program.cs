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
        const string name = "Wellington Silva";
        Logger logger = new();
        Model model = new
        (
            minified: false,
            title: name
        );
        
        #region Index
        logger.Information("Page: index (start)");
        Syntax.Clear();
        Syntax.Heading(name, HeadingLevel.Is1);
        Syntax.Heading("Software Developer | .NET | SQL Server | Python", HeadingLevel.Is2);
        Syntax.Paragraph("Software Developer | .NET | SQL Server | Python");
        Syntax.Super("Software Developer | .NET | SQL Server | Python", "h2");
        Syntax.Super("Software Developer | .NET | SQL Server | Python", "p");
        model.Main = Syntax.ToString();
        string indexHtml = Render(model);
        logger.Information("Page: index (complete)");
        #endregion
        
        Syntax.Clear();
        logger.Information("Page: about (start)");
        Syntax.Heading(name, HeadingLevel.Is1);
        model.Main = Syntax.ToString();
        string aboutHtml = Render(model);
        logger.Information("Page: about (complete)");
        
        logger.Information("save in html (start)");
        string indexPath = FilePath.Combine();
        string aboutPath = FilePath.Combine("about");
        File.WriteAllText(indexPath, indexHtml);
        File.WriteAllText(aboutPath, aboutHtml);
        logger.Information("save in html (start)");
        
        logger.Export();
    }
}