using System.Text;

namespace Aspa.Shared.Logger;

public class Service
{
    private const string FolderPath = "log";
    private const string Extension = ".log";
    private readonly StringBuilder _content;

    public Service()
    {
        _content = new StringBuilder();
        Information("Aspa (start)");
    }
    
    private void Log(string message, Level level)
    {
        _content.AppendLine($"{DateTime.UtcNow:O} [{level.ToString()}] {message}"); //ISO 8601
    }
    
    public void Verbose(string message) => Log(message, Level.Verbose);
    public void Debug(string message) => Log(message, Level.Debug);
    public void Information(string message) => Log(message, Level.Information);
    public void Warning(string message) => Log(message, Level.Warning);
    public void Error(string message) => Log(message, Level.Error);
    public void Fatal(string message) => Log(message, Level.Fatal);
    
    public void Export(string filename = "aspa")
    {
        Information("Aspa (complete)");
        filename += Extension;
        string filePath = Path.Combine(FolderPath, filename);
        File.AppendAllText(filePath, _content.ToString());
    }
    
    public string CurrentLogContent => _content.ToString();
}