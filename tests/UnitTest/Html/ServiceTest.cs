using Aspa.Html.Constants;
using Aspa.Html.Layout;
using Aspa.Html.Utils;
using Aspa.Shared;

namespace UnitTest.Html;

public class ServiceTest
{

    [Fact(DisplayName = "Verify minification works correctly")]
    public void Render_ReturnsMinifiedHtml_WhenMinified()
    {
        // Arrange
        const string title = "Minified Title";
        Syntax.Paragraph("This is a paragraph.");
        Syntax.Heading("h1", LevelTag.Is1);
        string mainContent = Syntax.ToString();

        var model = new Model
        (
            Minified: true, // Set to true for minification
            Title: title,
            Main: mainContent
        );

        // Expected Minified HTML (manual minification for comparison)
        // This simulates what your Minify.Get method should produce
        string expectedMinifiedHtml =
            Minify.Get(
                Template.NewCss
                    .Replace($"<{Tag.Title}></{Tag.Title}>", $"<{Tag.Title}>{title}</{Tag.Title}>")
                    .Replace($"<{Tag.Main}></{Tag.Main}>", $"<{Tag.Main}>\n            {mainContent} \n        </{Tag.Main}>")
            );

        // Act
        string renderedHtml = Service.Render(model);

        // Assert
        Assert.Equal(expectedMinifiedHtml, renderedHtml);
        // Also assert that it no longer contains unminified characteristics like newlines
        Assert.DoesNotContain("\n", renderedHtml);
        Assert.DoesNotContain("\r", renderedHtml);
        Assert.DoesNotContain("    ", renderedHtml); // Check for multiple spaces from indentation
    }

    [Fact(DisplayName = "Verify the specific indentation of the main body")]
    public void Render_AppliesCorrectMainContentIndentation()
    {
        // Arrange
        const string title = "Indentation Test";
        const string simpleMain = "<p>Simple content.</p>";

        var model = new Model
        (
            Minified: false,
            Title: title,
            Main: simpleMain
        );

        // Act
        string renderedHtml = Service.Render(model);

        // Assert
        // We expect the main content to be surrounded by:
        //"<{Tag.Main}>\n{model.Main}        </{Tag.Main}>";
        Assert.Contains($"<{Tag.Main}>\n{simpleMain}        </{Tag.Main}>", renderedHtml);
    }
}