using Aspa.html;

namespace Aspa;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Aspa (start)");

        _ = new Builder();

        Console.WriteLine("Aspa (complete)");
    }
}