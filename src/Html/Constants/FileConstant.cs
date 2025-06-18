namespace Aspa.Html.Constants;

public static class FileConstant
{
    private const string FolderPath = "public";
    private const string Extension = ".html";
    
    public static string Combine(string filename = "index")
    {
        filename += Extension;
        return Path.Combine(FolderPath, filename);
    }
}