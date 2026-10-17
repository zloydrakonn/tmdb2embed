using Tmdb2Embed.Models;

namespace Tmdb2Embed.Services;

public static class MbdParser
{
    public static List<EmbedTemplate> GetListOfEmbeds(FileInfo filePath) 
    {
        return ReadFile(filePath).Select(ParseLine).ToList();
    }
    
    public static IEnumerable<string> ReadFile(FileInfo filePath)
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
    
    public static EmbedTemplate ParseLine(string line)
    {
        var parts = line.Split(" ");
        return new EmbedTemplate(parts[0], parts[1]);
    }


}