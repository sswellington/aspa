using Aspa.Shared.Logger;

namespace UnitTest.Shared;

public class LoggerTest
{
    [Theory]
    [InlineData("This is a verbose message.", Level.Verbose)]
    [InlineData("This is a debug message.", Level.Debug)]
    [InlineData("This is an information message.", Level.Information)]
    [InlineData("This is a warning message.", Level.Warning)]
    [InlineData("This is an error message.", Level.Error)]
    [InlineData("This is a fatal message.", Level.Fatal)]
    public void Service_LogsSpecificLevelMessageCorrectly(string message, Level level)
    {
        // Arrange
        var service = new Service(); // A Service instance starts with "Aspa (start)"

        // Act
        // Call the specific log method based on the 'level' parameter
        switch (level)
        {
            case Level.Verbose: service.Verbose(message); break;
            case Level.Debug: service.Debug(message); break;
            case Level.Information: service.Information(message); break;
            case Level.Warning: service.Warning(message); break;
            case Level.Error: service.Error(message); break;
            case Level.Fatal: service.Fatal(message); break;
            default: throw new ArgumentOutOfRangeException(nameof(level), level, "Unexpected log level.");
        }

        // Assert
        // All tests should contain the initial "Aspa (start)" message
        Assert.Contains("Aspa (start)", service.CurrentLogContent);
        Assert.Contains("[Information]", service.CurrentLogContent); // The constructor logs "Information"

        // Verify the specific message and its level are present
        Assert.Contains(message, service.CurrentLogContent);
        Assert.Contains($"[{level.ToString()}]", service.CurrentLogContent);

        // Verify that the "Aspa (complete)" message is NOT present, as Export was not called
        Assert.DoesNotContain("Aspa (complete)", service.CurrentLogContent);
    }

    // You could also have a single test to check all messages if you prefer,
    // but the Theory approach is generally more robust for individual level verification.
    [Fact]
    public void Service_LogsAllMessageTypesSequentially()
    {
        // Arrange
        var service = new Service();
        string verboseMsg = "Msg V";
        string debugMsg = "Msg D";
        string infoMsg = "Msg I";
        string warnMsg = "Msg W";
        string errorMsg = "Msg E";
        string fatalMsg = "Msg F";

        // Act
        service.Verbose(verboseMsg);
        service.Debug(debugMsg);
        service.Information(infoMsg); // Note: another Information call after initial
        service.Warning(warnMsg);
        service.Error(errorMsg);
        service.Fatal(fatalMsg);

        // Assert
        string content = service.CurrentLogContent;

        // Verify initial constructor log
        Assert.Contains("Aspa (start)", content);
        Assert.Contains("[Information]", content); // Initial log level

        // Verify all specific messages and their levels
        Assert.Contains(verboseMsg, content);
        Assert.Contains($"[{Level.Verbose}]", content);

        Assert.Contains(debugMsg, content);
        Assert.Contains($"[{Level.Debug}]", content);

        Assert.Contains(infoMsg, content);
        Assert.Contains($"[{Level.Information}]", content);

        Assert.Contains(warnMsg, content);
        Assert.Contains($"[{Level.Warning}]", content);

        Assert.Contains(errorMsg, content);
        Assert.Contains($"[{Level.Error}]", content);

        Assert.Contains(fatalMsg, content);
        Assert.Contains($"[{Level.Fatal}]", content);

        // Ensure "Aspa (complete)" is NOT present
        Assert.DoesNotContain("Aspa (complete)", content);
    }
}