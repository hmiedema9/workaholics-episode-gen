using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using BlazorApp.Shared;
using System.IO;

namespace BlazorApp.Api
{
    public static class RandomEpisodeFunction
    {
        [FunctionName("RandomEpisode")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            var json = File.ReadAllText(Path.Combine(context.FunctionAppDirectory, "data/workaholics.json"));
            var episodes = System.Text.Json.JsonSerializer.Deserialize<Episode[]>(json);
            System.Random rand = new System.Random();
            var randomEpisode = rand.Next(0, episodes.Length);
            return new OkObjectResult(episodes[randomEpisode]);
        }
    }
}
