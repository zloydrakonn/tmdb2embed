
using System.CommandLine;
using Tmdb2Embed.Services;

var tmdbId = new Argument<int>("tmdbId");
var type = new Argument<string>("type");
var file = new Option<FileInfo>("--file", "-f")
{
    Required = true
};

var root = new RootCommand("generates link for embed-sites by TMDB ID");
root.Arguments.Add(tmdbId);
root.Arguments.Add(type);
root.Options.Add(file);

root.SetAction(r =>
{
    int id = r.GetValue(tmdbId);
    string t = r.GetValue(type)!;
    FileInfo f = r.GetValue(file)!;
    var embedList = MbdParser.GetListOfEmbeds(f);
    foreach (var template in embedList)
    {
        if (t == "movie") Console.WriteLine(template.MovieTemplate);
        else Console.WriteLine(template.TvTemplate);
    }
    
});

return root.Parse(args).Invoke();