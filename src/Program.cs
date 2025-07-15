using Aspa.Html.Constants;
using Aspa.Html.Pages;
using Aspa.Html.Utils;
using Aspa.Shared;

namespace Aspa;

internal static class Program
{
    private static void Main()
    {
        const string name = "Wellington Silva";
        
        FileService fileService = new FileService();
        LoggerService logger = fileService.Logger;
        
        #region Index
        logger.Information("Page: index (start)");
        Syntax.Clear();
        Syntax.InjectHtml(Linktree.Html);
        string indexHtml = Syntax.Render(title: name, Syntax.ToString(), false);
        logger.Information("Page: index (complete)");
        #endregion
        
        #region About
        logger.Information("Page: about (start)");
        Syntax.Clear();
        Syntax.InjectHtml(About.Html);
        string aboutHtml = Syntax.Render(title: name + " - Sobre", Syntax.ToString(), false);
        logger.Information("Page: about (complete)");
        #endregion

        #region Save
        logger.Information("save in html (start)");
        string indexPath = FilePath.Combine();
        string aboutPath = FilePath.Combine("sobre");
        
        File.WriteAllText(indexPath, indexHtml);
        File.WriteAllText(aboutPath, aboutHtml);
        logger.Information("save in html (start)");
        #endregion
        
        logger.Export();
    }
}