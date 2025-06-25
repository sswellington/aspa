using Aspa.Html.Constants;

namespace UnitTest.Html;

public class FileConstantTest
{
    [Fact(DisplayName = "Combine with default filename")]
    public void Combine_UsesDefaultFilename_WhenNoFilenameProvided()
    {
        // Arrange
        string expectedFolderPath = "public"; // Your FolderPath
        string expectedExtension = ".html";  // Your Extension
        string expectedFilename = "index"; // Your default filename
        string expectedPath = Path.Combine(expectedFolderPath, expectedFilename + expectedExtension);

        // Act
        string actualPath = FileConstant.Combine();

        // Assert
        Assert.Equal(expectedPath, actualPath);
    }

    [Fact(DisplayName = "Combine with a custom filename")]
    public void Combine_UsesCustomFilename_WhenFilenameProvided()
    {
        // Arrange
        string expectedFolderPath = "public";
        string expectedExtension = ".html";
        string customFilename = "my_page";
        string expectedPath = Path.Combine(expectedFolderPath, customFilename + expectedExtension);

        // Act
        string actualPath = FileConstant.Combine(customFilename);

        // Assert
        Assert.Equal(expectedPath, actualPath);
    }

    [Fact(DisplayName = "Check for correct extension")]
    public void Combine_AppendsCorrectExtension()
    {
        // Arrange
        string filename = "test_file";
        string expectedExtension = ".html";
        Path.Combine("public", filename + expectedExtension);

        // Act
        string actualPath = FileConstant.Combine(filename);

        // Assert
        Assert.EndsWith(expectedExtension, actualPath);
    }

    [Fact(DisplayName = "Handling edge cases like empty filename")]
    public void Combine_HandlesEmptyFilename()
    {
        // Arrange
        string expectedFolderPath = "public";
        string expectedExtension = ".html";
        string expectedPath = Path.Combine(expectedFolderPath, expectedExtension); // "public/.html"

        // Act
        string actualPath = FileConstant.Combine(""); // Empty string

        // Assert
        Assert.Equal(expectedPath, actualPath);
    }
    
    [Fact(DisplayName = "Filename with spaces or special characters")]
    public void Combine_HandlesFilenameWithSpacesAndSpecialCharacters()
    {
        // Arrange
        string filename = "my file with spaces and -_#@!";
        string expectedFolderPath = "public";
        string expectedExtension = ".html";
        string expectedPath = Path.Combine(expectedFolderPath, filename + expectedExtension);

        // Act
        string actualPath = FileConstant.Combine(filename);

        // Assert
        Assert.Equal(expectedPath, actualPath);
    }
}