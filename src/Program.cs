using Aspa.Html.Constants;
using Aspa.Html.Layout;
using Aspa.Html.Utils;
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
        string indexHtml = model.Render();
        logger.Information("Page: index (complete)");
        #endregion

        #region About
        Syntax.Clear();
        logger.Information("Page: about (start)");
        Syntax.Heading(name, HeadingLevel.Is1);
        model.Main = Syntax.ToString();
        string aboutHtml = model.Render();
        logger.Information("Page: about (complete)");
        #endregion
        
        #region About
        Syntax.Clear();
        logger.Information("Page: blog (start)");
        Syntax.Heading(name, HeadingLevel.Is1);
        model.Main = Syntax.ToString();
        string blogHtml = model.Render();
        logger.Information("Page: blog (complete)");
        #endregion

        #region save
        logger.Information("save in html (start)");
        string indexPath = FilePath.Combine();
        string aboutPath = FilePath.Combine("about");
        string blogPath = FilePath.Combine("blog");
        File.WriteAllText(indexPath, indexHtml);
        File.WriteAllText(aboutPath, aboutHtml);
        File.WriteAllText(blogPath, blogHtml);
        logger.Information("save in html (start)");
        #endregion
        
        logger.Export();
    }
}