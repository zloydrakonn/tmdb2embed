
using System.CommandLine;
using Tmdb2Embed.Services;

var tmdbId = new Argument<int>("tmdbId");
var type = new Argument<string>("type");
var season = new Argument<string>("season");
var episode = new Argument<string>("episode");
var file = new Option<FileInfo>("--file", "-f")
{
    Required = true
};

var root = new RootCommand("Generates link for embed-sites by TMDB ID");
root.Arguments.Add(tmdbId);
root.Arguments.Add(type);
root.Arguments.Add(season);
root.Arguments.Add(episode);
root.Options.Add(file);

root.Validators.Add(r =>
{
    string contentType = r.GetValue(type)!;
    string tvSeason = r.GetValue(season)!;
    string tvEpisode = r.GetValue(episode)!;
    if (contentType == "tv")
    {
        if(string.IsNullOrEmpty(tvSeason) || string.IsNullOrEmpty(tvEpisode))
        {
            r.AddError("The 'tv' type requires <season> and <episode>");
        }
    }
});

root.SetAction(r =>
{
    int id = r.GetValue(tmdbId);
    string contentType = r.GetValue(type)!;
    string tvSeason = r.GetValue(season)!;
    string tvEpisode = r.GetValue(episode)!;

    FileInfo pathFile = r.GetValue(file)!;

    var embedList = MbdParser.GetListOfEmbeds(pathFile);


    foreach (var template in embedList)
    {
        if (contentType == "movie") Console.WriteLine(template.MovieTemplate);
        else Console.WriteLine(template.TvTemplate);
    }
    
});

return root.Parse(args).Invoke();