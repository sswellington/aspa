using System.Text;

namespace Aspa.Shared.Logger;

public sealed class Service
{
    private const string FolderPath = "log";
    private const string Extension = ".log";
    private readonly StringBuilder _content;

    public Service()
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