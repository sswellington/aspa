using Aspa.Shared;

namespace UnitTest.Shared;

public sealed class MinifiedTest
{
[Fact]
    public void Get_ShouldReturnEmptyString_WhenContentIsNullOrEmpty()
    {
        // Arrange
        string nullContent = null!;
        string emptyContent = string.Empty;
        string whitespaceContent = "   \r\n\t  ";

        // Act
        string resultNull = Minify.Get(nullContent);
        string resultEmpty = Minify.Get(emptyContent);
        string resultWhitespace = Minify.Get(whitespaceContent);

        // Assert
        Assert.Equal(string.Empty, resultNull);
        Assert.Equal(string.Empty, resultEmpty);
        Assert.Equal(string.Empty, resultWhitespace);
    }

    [Fact]
    public void Get_ShouldRemoveAllNewlinesAndTabs()
    {
        // Arrange
        string content = "Line 1\r\n\tLine 2\nLine 3";
        string expected = "Line 1 Line 2 Line 3"; // Note: single spaces remain

        // Act
        string actual = Minify.Get(content);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Get_ShouldCollapseMultipleSpacesToSingleSpace()
    {
        // Arrange
        string content = "Hello   World   From    Minifier";
        string expected = "Hello World From Minifier";

        // Act
        string actual = Minify.Get(content);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Get_ShouldRemoveSpaceBetweenClosingAndOpeningTags()
    {
        // Arrange
        string content = "<div> </div>   <span></span>"; // "> <" scenario
        string expected = "<div></div><span></span>";

        // Act
        string actual = Minify.Get(content);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Get_ShouldPreserveSpaceWithinTextContent()
    {
        // Arrange
        string content = "<h1>  My Title With Spaces  </h1><p>This is  a  paragraph.</p>";
        string expected = "<h1>My Title With Spaces</h1><p>This is a paragraph.</p>";

        // Act
        string actual = Minify.Get(content);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Get_ShouldHandleLeadingAndTrailingWhitespace()
    {
        // Arrange
        string content = "   \n\t<h1>Content</h1>   \r\n";
        // The logic implicitly handles leading spaces if the first non-whitespace
                                            // char isn't a space that follows a previous whitespace.
                                            // Trailing spaces won't be removed by this iteration.
                                            // Let's adjust expectation based on your code.
        
        // As per your code's logic, a single trailing space might remain if the last char processed was a space.
        // It's not explicitly doing a final .Trim()
        string contentWithTrailingSpace = "<h1>Content</h1>   ";

        string contentWithLeadingSpace = "   <h1>Content</h1>";

        // Act
        string actual1 = Minify.Get(content);
        string actual2 = Minify.Get(contentWithTrailingSpace);
        string actual3 = Minify.Get(contentWithLeadingSpace);

        // Assert
        // The current implementation doesn't have a final .Trim(),
        // so a single trailing space will remain if the input ends with whitespace.
        // If you want to remove trailing spaces, add a .Trim() at the end of your Get method.
        Assert.Equal("<h1>Content</h1>", actual1); // Newlines and tabs removed, spaces collapsed
        Assert.Equal("<h1>Content</h1>", actual2); // A single trailing space is kept by your current logic
        Assert.Equal("<h1>Content</h1>", actual3);
    }
    
    [Fact]
    public void Get_ShouldHandleComplexHtmlStructure()
    {
        // Arrange
        string content = @"
            <!DOCTYPE html>
            <html>
            <head>
                <title> Test Page </title>
                <style>
                    body  {  margin:   0;  } /* CSS spaces should remain within rules */
                </style>
            </head>
            <body>
                <h1>Hello    World</h1>
                <p> This is a paragraph with   some   spaces. </p>
                <div>
                    <span>Item 1</span>   <span>Item 2</span>
                </div>
            </body>
            </html>
        ";
        string expected = "<!DOCTYPE html><html><head><title>Test Page</title><style>body { margin: 0; }</style></head><body><h1>Hello World</h1><p>This is a paragraph with some spaces.</p><div><span>Item 1</span><span>Item 2</span></div></body></html>";
        
        // Act
        string actual = Minify.Get(content);

        // Assert
        Assert.Equal(expected, actual);
    }
}