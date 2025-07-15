namespace Aspa.Html.Constants;

public static class FilePath
{
    public static string FolderPath => "public";
    private static string Extension => ".html";
    
    public static string Combine(string filename = "index")
    {
        return Path.Combine(FolderPath, $"{filename}{Extension}");
    }
}