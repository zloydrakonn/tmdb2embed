
using System.CommandLine;
using Tmdb2Embed.Services;

var tmdbId = new Argument<int>("tmdbId");
tmdbId.Description = "The TMDB ID of the TV show/movie";
var season = new Argument<int>("season");
season.Description = "Season number";
var episode = new Argument<int>("episode");
episode.Description = "Episode number";

var file = new Option<FileInfo>("--file", "-f");
file.Required = true;

var movieCommand = new Command("movie", "Generate links for a movie");
movieCommand.Arguments.Add(tmdbId);
movieCommand.Options.Add(file);

var tvCommand = new Command("tv", "Generate links for a TV show episode");
tvCommand.Arguments.Add(tmdbId);
tvCommand.Arguments.Add(season);
tvCommand.Arguments.Add(episode);
tvCommand.Options.Add(file);

var root = new RootCommand("Generates link for embed-sites by TMDB ID");
root.Subcommands.Add(movieCommand);
root.Subcommands.Add(tvCommand);

movieCommand.SetAction(r =>
{
    int id = r.GetValue(tmdbId);

    FileInfo pathFile = r.GetValue(file)!;
    if (pathFile.Exists)
    {
            var embedList = EmbedBuilder.BuildAll(MbdParser.GetListOfEmbeds(pathFile), id);
        foreach (var embed in embedList)
        {
            Console.WriteLine(embed);
        }
        return 0;
    }
    else
    {
        return ErrorHandler.FileNotFound(pathFile);
    }

    
});

tvCommand.SetAction(r =>
{
    int id = r.GetValue(tmdbId);
    int tvSeason = r.GetValue(season)!;
    int tvEpisode = r.GetValue(episode)!;
    FileInfo pathFile = r.GetValue(file)!;

    if (pathFile.Exists)
    {
            var embedList =  EmbedBuilder.BuildAll(MbdParser.GetListOfEmbeds(pathFile), id, tvSeason, tvEpisode);
        foreach (var embed in embedList)
        {
            Console.WriteLine(embed);
        }
        return 0;
    }
    else
    {
        return ErrorHandler.FileNotFound(pathFile);
    }
});

return root.Parse(args).Invoke();