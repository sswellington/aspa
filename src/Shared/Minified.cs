using System.Text;

namespace Aspa.Shared;

public static class Minify
{
    public static string Get(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            return string.Empty;

        bool prevCharWasSpace = false;
        StringBuilder sb = new(content.Length);

        foreach (char c in content)
        {
            switch (c)
            {
                case '\r':
                case '\n':
                case '\t':
                    continue;
                case '<':
                    if (prevCharWasSpace)
                    {
                        sb.Length--;
                    }
                    sb.Append('<');
                    prevCharWasSpace = false;
                    break;
                case '>':
                    sb.Append('>');
                    prevCharWasSpace = false;
                    break;
                case ' ':
                    if (!prevCharWasSpace)
                    {
                        sb.Append(' ');
                        prevCharWasSpace = true;
                    }
                    break;
                default:
                    sb.Append(c);
                    prevCharWasSpace = false;
                    break;
            }
        }

        return sb.ToString();
    }
}