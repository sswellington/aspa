

using System.Text.RegularExpressions;
using Aspa.Html.Constants;

namespace UnitTest.Html.Constants;

public class TemplateTest
{
    // The TestableHtmlGenerator class is removed as we are testing Aspa.Html.Constants.Template.Base
    // You must ensure that the 'Template' class with the 'Base' method is accessible
    // from this test project.

    [Fact]
    public void Base_ShouldGenerateValidHtmlStructure()
    {
        // Arrange
        string cssLinks = "<link rel=\"stylesheet\" href=\"custom.css\" />";
        string jsScripts = "<script src=\"custom.js\"></script>";

        // Act
        // Now calling Template.Base directly, assuming it's a static method in the Template class
        string html = Template.Base(cssLinks, jsScripts);

        // Assert
        // Verify the presence of essential HTML tags
        Assert.Contains("<!DOCTYPE", html);
        Assert.Contains("<html", html);
        Assert.Contains("<head>", html);
        Assert.Contains("</head>", html);
        Assert.Contains("<body>", html);
        Assert.Contains("</body>", html);
        Assert.Contains("</html>", html);
        Assert.Contains("<title>", html); // Even if empty, it's an essential tag

        // Verify correct injection of CSS links
        Assert.Contains(cssLinks, html);
        Assert.Matches("(?s)<head>.*?" + Regex.Escape(cssLinks) + ".*?</head>", html);

        // Verify correct injection of JavaScript scripts
        Assert.Contains(jsScripts, html);
        Assert.Matches("(?s)<body>.*?" + Regex.Escape(jsScripts) + ".*?</body>", html);

        // Verify some specific structural tags to ensure the base template is present
        Assert.Contains("<meta charset='utf-8'>", html);
        Assert.Contains("<header>", html);
        Assert.Contains("<nav id=\"nav\">", html);
        Assert.Contains("<main></main>", html);
    }

    [Fact]
    public void Base_ShouldHandleEmptyCssAndJsLinks()
    {
        // Arrange
        string cssLinks = "";
        string jsScripts = "";

        // Act
        string html = Template.Base(cssLinks, jsScripts); // Call Template.Base

        // Assert
        // Ensure the HTML is still valid and injection sections are empty
        Assert.Contains("<!DOCTYPE", html);
        Assert.Contains("<html", html);
        Assert.Contains("<head>", html);
        Assert.Contains("</body>", html);
        Assert.DoesNotContain("<link rel=\"stylesheet\" href=\"custom.css\" />", html); // Confirm nothing was injected
        Assert.DoesNotContain("<script src=\"custom.js\"></script>", html); // Confirm nothing was injected
    }

    [Fact]
    public void Base_ShouldInjectMultipleCssAndJsLinks()
    {
        // Arrange
        string multipleCssLinks = "<link rel=\"stylesheet\" href=\"style1.css\" /><link rel=\"stylesheet\" href=\"style2.css\" />";
        string multipleJsScripts = "<script src=\"script1.js\"></script><script src=\"script2.js\"></script>";

        // Act
        string html = Template.Base(multipleCssLinks, multipleJsScripts); // Call Template.Base

        // Assert
        Assert.Contains(multipleCssLinks, html);
        Assert.Matches("(?s)<head>.*?" + Regex.Escape(multipleCssLinks) + ".*?</head>", html);

        Assert.Contains(multipleJsScripts, html);
        Assert.Matches("(?s)<body>.*?" + Regex.Escape(multipleJsScripts) + ".*?</body>", html);
    }
}