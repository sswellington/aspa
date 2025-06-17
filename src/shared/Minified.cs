namespace Aspa.shared;

public static class Minify
{
    public static string Get(string content)
    {
        return content
            .Replace("\r\n", "")
            .Replace("\n", "")
            .Replace("\t", "")
            .Replace(" ", "")
            .Trim();
    }
}