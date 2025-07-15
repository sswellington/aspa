using System.Text;

namespace Aspa.Shared;

/// <summary>
/// Represents the importance levels for log events, following the Serilog convention.
/// Levels are listed in increasing order of importance:
/// <list type="number">
///     <item><term><b>Verbose: </b></term><description>Tracing information and debugging minutiae; generally only switched on in unusual situations.</description></item>
///     <item><term><b>Debug: </b></term><description>Internal control flow and diagnostic state dumps to facilitate pinpointing of recognized problems.</description></item>
///     <item><term><b>Information: </b></term><description>Events of interest or that have relevance to outside observers; the default enabled minimum logging level.</description></item>
///     <item><term><b>Warning: </b></term><description>Indicators of possible issues or service/functionality degradation.</description></item>
///     <item><term><b>Error: </b></term><description>Indicates a failure within the application or connected system.</description></item>
///     <item><term><b>Fatal: </b></term><description>Critical errors causing complete failure of the application.</description></item>
/// </list>
/// For more details, refer to: <a href="https://github.com/serilog/serilog/wiki/Writing-Log-Events#log-event-levels">Serilog Wiki - Log Event Levels</a>
/// </summary>
public enum Level
{
    Verbose = 1,
    Debug = 2,
    Information = 3,
    Warning = 4,
    Error = 5,
    Fatal = 6
}

public sealed class LoggerService
{
    private const string FolderPath = "log";
    private const string Extension = ".log";
    private readonly StringBuilder _content;

    public LoggerService()
    {
        _content = new StringBuilder();
        Information("Aspa (start)");
    }

    private static string Format(string message, Level level = Level.Information)
    {
        return $"{DateTime.UtcNow:O} [{Enum.GetName(level)!}] {message}"; //ISO 8601
    }
    
    private void Log(string log)
    {
        _content.AppendLine(log);
    }
    
    public void Verbose(string message)
    {
        string logger = Format(message, Level.Verbose);
        #if DEBUG
            Console.WriteLine(logger);
        #endif
        Log(logger);
    }

    public void Debug(string message)
    {
        string logger = Format(message, Level.Debug);
        #if DEBUG
            Console.WriteLine(logger);
        #endif
        Log(logger);
    }

    public void Information(string message)
    {
        Log(Format(message));
    }

    public void Warning(string message)
    {
        Log(Format(message, Level.Warning));
    }

    public void Error(string message)
    {
        Log(Format(message, Level.Error));
    }

    public void Fatal(string message)
    {
        Log(Format(message, Level.Fatal));
    }

    public void Export(string filename = "aspa")
    {
        Information("Aspa (complete)");
        filename += Extension;
        string filePath = Path.Combine(FolderPath, filename);
        File.AppendAllText(filePath, _content.ToString());
    }
    
    public string CurrentLogContent => _content.ToString();
}