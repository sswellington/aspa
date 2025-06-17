using Aspa.html;
using Aspa.html.Constants;

namespace Aspa;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine($"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - Aspa (start)");

        Model model = new();
        Layout layout = new(model);
        string filePath = FileConstant.Combine("index");
        string html = layout.ToHtml;
        
        File.WriteAllText(filePath, html);

        Console.WriteLine($"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - Aspa (complete)");
    }
}