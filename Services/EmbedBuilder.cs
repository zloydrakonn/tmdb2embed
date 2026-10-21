using Tmdb2Embed.Models;

namespace Tmdb2Embed.Services;

public static class EmbedBuilder
{
    public static string BuildTv(EmbedTemplate template, int id, int season, int episode)
    {
        return template.TvTemplate
        .Replace("{tmdbId}", id.ToString())
        .Replace("{season}", season.ToString())
        .Replace("{episode}", episode.ToString());
    }
    public static string BuildMovie(EmbedTemplate template, int id)
    {
        return template.TvTemplate
        .Replace("{tmdbId}", id.ToString());
    }
    public static List<string> BuildAllTvs(List<EmbedTemplate> embedTemplates, int id, int season, int episode)
    {
        var tvUrls = new List<string>();
        foreach (var template in embedTemplates)
        {
            string url = template.TvTemplate
            .Replace("{tmdbId}", id.ToString())
            .Replace("{season}", season.ToString())
            .Replace("{episode}", episode.ToString());
            tvUrls.Add(url);
        }
        return tvUrls;
    }
    public static List<string> BuildAllMovies(List<EmbedTemplate> embedTemplates, int id)
    {
        var movieUrls = new List<string>();
        foreach (var template in embedTemplates)
        {
            string url = template.MovieTemplate
            .Replace("{tmdbId}", id.ToString());
            movieUrls.Add(url);
        }
        return movieUrls;
    }
}