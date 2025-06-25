namespace Aspa.Html.Constants;

public static class FileConstant
{
    private static string FolderPath => "public";
    private static string Extension => ".html";
    
    public static string Combine(string filename = "index")
    {
        filename += Extension;
        return Path.Combine(FolderPath, filename);
    }
}