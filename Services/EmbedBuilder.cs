using Tmdb2Embed.Models;

namespace Tmdb2Embed.Services;

public static class EmbedBuilder
{
    public static string Build(EmbedTemplate template, int tvId, int season, int episode)
    {
        return template.TvTemplate
        .Replace("{tmdbId}", tvId.ToString())
        .Replace("{season}", season.ToString())
        .Replace("{episode}", episode.ToString());
    }
    public static string Build(EmbedTemplate template, int movieId)
    {
        return template.MovieTemplate
        .Replace("{tmdbId}", movieId.ToString());
    }
    public static List<string> BuildAll(List<EmbedTemplate> embedTemplates, int tvId, int season, int episode)
    {
        var tvUrls = new List<string>();
        foreach (var template in embedTemplates)
        {
            string url = template.TvTemplate
            .Replace("{tmdbId}", tvId.ToString())
            .Replace("{season}", season.ToString())
            .Replace("{episode}", episode.ToString());
            tvUrls.Add(url);
        }
        return tvUrls;
    }
    public static List<string> BuildAll(List<EmbedTemplate> embedTemplates, int movieId)
    {
        var movieUrls = new List<string>();
        foreach (var template in embedTemplates)
        {
            string url = template.MovieTemplate
            .Replace("{tmdbId}", movieId.ToString());
            movieUrls.Add(url);
        }
        return movieUrls;
    }
}