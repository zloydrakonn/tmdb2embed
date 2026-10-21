namespace Tmdb2Embed.Services;
public static class ErrorHandler
{
    public static int Print(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine($"Error: File not found: {message}");
        Console.ResetColor();
        return 1;
    }
    public static int FileNotFound(FileInfo filePath)
    {
        var message = $"File not found: {filePath}";
        return Print(message);
    }
}