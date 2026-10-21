using Tmdb2Embed.Models;

namespace Tmdb2Embed.Services;

public static class MbdParser
{
    public static List<EmbedTemplate> GetListOfEmbeds(FileInfo filePath) 
    {
        return FileOperator.EnumerateLines(filePath).Select(ParseLine).ToList();
    }

    public static EmbedTemplate ParseLine(string line)
    {
        var parts = line.Split(" ");
        return new EmbedTemplate(parts[0], parts[1]);
    }


}