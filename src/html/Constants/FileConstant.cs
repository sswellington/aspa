using System.Diagnostics;

namespace Aspa.html.Constants;

public static class FileConstant
{
    public const string FolderPath = "public";
    public const string Extension = ".html";
    
    public static string Combine(string filename)
    {
        Debug.Assert(filename != null, nameof(filename) + " != null");
        filename += Extension;
        return Path.Combine(FolderPath, filename);
    }
}