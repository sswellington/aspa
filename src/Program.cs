using Aspa.Html.Constants;
using Aspa.Html.Utils;
using Logger = Aspa.Shared.Logger.Service;

namespace Aspa;

internal static class Program
{
    private static void Main()
    {
        const string name = "Wellington Silva";
        Logger logger = new();
        
        #region Index
        logger.Information("Page: index (start)");
        Syntax.Clear();
        Syntax.Heading(name, HeadingLevel.Is1);
        Syntax.Heading("Software Developer", HeadingLevel.Is4);
        string indexHtml = Syntax.Render(title: name, Syntax.ToString(), false);
        logger.Information("Page: index (complete)");
        #endregion

        #region About
        logger.Information("Page: about (start)");
        Syntax.Clear();
        Syntax.Heading("Sobre", HeadingLevel.Is1);
        string aboutHtml = Syntax.Render(title: name + " - Sobre", Syntax.ToString(), false);
        logger.Information("Page: about (complete)");
        #endregion
        
        #region Blog
        Syntax.Clear();
        logger.Information("Page: blog (start)");
        Syntax.Heading("Blog", HeadingLevel.Is1);
        string blogHtml = Syntax.Render(title: name + " - about", Syntax.ToString(), false);
        logger.Information("Page: blog (complete)");
        #endregion

        #region save
        logger.Information("save in html (start)");
        string indexPath = FilePath.Combine();
        string aboutPath = FilePath.Combine("sobre");
        string blogPath = FilePath.Combine("blog");
        
        File.WriteAllText(indexPath, indexHtml);
        File.WriteAllText(aboutPath, aboutHtml);
        File.WriteAllText(blogPath, blogHtml);
        logger.Information("save in html (start)");
        #endregion
        
        logger.Export();
    }
}