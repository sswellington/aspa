using Aspa.Html.Constants;

namespace UnitTest.Html.Constants;

public class FilePathTest
{
    [Fact(DisplayName = "Combine with default filename")]
    public void Combine_UsesDefaultFilename_WhenNoFilenameProvided()
    {
        // Arrange
        const string expectedFolderPath = "public";
        const string expectedExtension = ".html";
        const string expectedFilename = "index";
        string expectedPath = Path.Combine(expectedFolderPath, expectedFilename + expectedExtension);

        // Act
        string actualPath = FilePath.Combine();

        // Assert
        Assert.Equal(expectedPath, actualPath);
    }

    [Fact(DisplayName = "Combine with a custom filename")]
    public void Combine_UsesCustomFilename_WhenFilenameProvided()
    {
        // Arrange
        const string expectedFolderPath = "public";
        const string expectedExtension = ".html";
        const string customFilename = "my_page";
        string expectedPath = Path.Combine(expectedFolderPath, customFilename + expectedExtension);

        // Act
        string actualPath = FilePath.Combine(customFilename);

        // Assert
        Assert.Equal(expectedPath, actualPath);
    }

    [Fact(DisplayName = "Check for correct extension")]
    public void Combine_AppendsCorrectExtension()
    {
        // Arrange
        const string filename = "test_file";
        const string expectedExtension = ".html";
        Path.Combine("public", filename + expectedExtension);

        // Act
        string actualPath = FilePath.Combine(filename);

        // Assert
        Assert.EndsWith(expectedExtension, actualPath);
    }

    [Fact(DisplayName = "Handling edge cases like empty filename")]
    public void Combine_HandlesEmptyFilename()
    {
        // Arrange
        const string expectedFolderPath = "public";
        const string expectedExtension = ".html";
        string expectedPath = Path.Combine(expectedFolderPath, expectedExtension); // "public/.html"

        // Act
        string actualPath = FilePath.Combine(""); // Empty string

        // Assert
        Assert.Equal(expectedPath, actualPath);
    }
    
    [Fact(DisplayName = "Filename with spaces or special characters")]
    public void Combine_HandlesFilenameWithSpacesAndSpecialCharacters()
    {
        // Arrange
        const string filename = "my file with spaces and -_#@!";
        const string expectedFolderPath = "public";
        const string expectedExtension = ".html";
        string expectedPath = Path.Combine(expectedFolderPath, filename + expectedExtension);

        // Act
        string actualPath = FilePath.Combine(filename);

        // Assert
        Assert.Equal(expectedPath, actualPath);
    }
}