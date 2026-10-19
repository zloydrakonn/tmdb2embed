namespace Tmdb2Embed.Services;

public static class FileOperator 
{
    public static IEnumerable<string> EnumerateLines(FileInfo filePath)
    {
        using (var streamReader = new StreamReader(filePath.FullName))
        {
            string? line;
            while ((line = streamReader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}