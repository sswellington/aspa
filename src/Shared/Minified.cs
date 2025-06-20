using System.Text;

namespace Aspa.Shared;

public static class Minify
{
    private static bool _inHtmlComment;
    private static bool _inCssComment;
    private static bool _prevCharWasWhitespace;
    private static bool _lastWasTagBoundary;

    private static void ResetFlags()
    {
        _inHtmlComment = false;
        _inCssComment = false;
        _prevCharWasWhitespace = true;
        _lastWasTagBoundary = false; 
    }
    
    /// <summary>
    /// Minifies an HTML/text content string by removing comments,
    /// collapsing excessive whitespace, and optimizing spacing around tags.
    /// This implementation uses a character-by-character loop without regular expressions.
    /// </summary>
    /// <param name="content">The input string to minify.</param>
    /// <returns>The minified string.</returns>
    public static string Get(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            return string.Empty;
        
        ResetFlags();
        StringBuilder sb = new(content.Length);
        for (int i = 0; i < content.Length; i++)
        {
            char c = content[i];

            // 1. Handle comment detection and skipping
            // This method updates 'i' and the comment flags by reference
            if (TryHandleComment(content, ref i))
            {
                continue; // Skip to next char if a comment was handled (either started or ended)
            }
            
            // If we are currently inside any type of comment, skip the character
            if (_inHtmlComment || _inCssComment)
            {
                continue;
            }

            #region Main character minification logic
            switch (c)
            {
                // Consolidate all types of whitespace here
                case '\r':
                case '\n':
                case '\t':
                case ' ': 
                    // If '_lastWasTagBoundary' is true, it means a tag boundary ('>' or '<')
                    // was just appended, so this immediate whitespace should be entirely skipped.
                    if (_lastWasTagBoundary)
                    {
                        continue;
                    }
                    
                    // Collapse multiple consecutive whitespaces into a single space.
                    // Append a space only if the previous character appended wasn't already a space.
                    if (!_prevCharWasWhitespace)
                    {
                        sb.Append(' ');
                        _prevCharWasWhitespace = true;
                    }
                    
                    _lastWasTagBoundary = false; // Reset the flag after handling a general space
                    break;

                case '<':
                    // If the character before '<' in the StringBuilder was a space, remove it.
                    // This handles cases like "text <tag>" becoming "text<tag>" or "</div> <div" becoming "</div><div".
                    if (_prevCharWasWhitespace && sb.Length > 0 && sb[sb.Length - 1] == ' ')
                    {
                        sb.Length--;
                    }
                    sb.Append('<');
                    _prevCharWasWhitespace = false;
                    // Set '_lastWasTagBoundary' to true, as the next whitespace immediately after '<'
                    // should typically be skipped (e.g., "<title> Test" -> "<title>Test").
                    _lastWasTagBoundary = true; 
                    break;

                case '>':
                    sb.Append('>');
                    _prevCharWasWhitespace = false;
                    _lastWasTagBoundary = true; 
                    break;
                
                default:
                    sb.Append(c);
                    _prevCharWasWhitespace = false;
                    _lastWasTagBoundary = false; // Resetamos a flag para caracteres normais
                    break;
            }
            #endregion
        }

        return sb.ToString().Trim();
    }

    #region  TryHandleComment
    private static bool IsComment(string content, int currentIndex, bool begin = true) 
    {
        if (currentIndex + 2 < content.Length && content[currentIndex] == '-' && content[currentIndex + 1] == '-' && content[currentIndex + 2] == '>')
            return true;
        
        if (!(currentIndex + 1 < content.Length))
            return false; 
            
        if (begin)
            return content[currentIndex] == '/' && content[currentIndex + 1] == '*';
        
        return content[currentIndex] == '*' && content[currentIndex + 1] == '/';
    }
    
    private static bool TryHandleComment(string content, ref int currentIndex)
    {
        const int currentIndexInHtml = 2;  
        bool isCommentInHtml = IsComment(content, currentIndex);
        bool isBeginningOfComment = IsComment(content, currentIndex);
        bool isEndeningOfComment = IsComment(content, currentIndex, begin: false);
        
        // Check for start of HTML comment
        if (_inHtmlComment && isCommentInHtml)
        {
            _inHtmlComment = false;
            currentIndex += currentIndexInHtml; // Advance index past "-->"
            return true;
        }

        // Check for start of CSS/JS comment (/*)
        if (!_inHtmlComment && !_inCssComment && isBeginningOfComment)
        {
            _inCssComment = true;
            currentIndex += 1; // Advance index past "*"
            return true;
        }
        
        // Check for end of CSS/JS comment (*/)
        if (_inCssComment && isEndeningOfComment)
        {
            _inCssComment = false;
            currentIndex += 1; // Advance index past "/"
            return true;
        }

        return false; // No comment sequence was found or handled at this position
    }
    #endregion
}