using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using BlazorApp.Shared;
using System.IO;

namespace BlazorApp.Api
{
    public static class EpisodesFunction
    {
        [FunctionName("Episodes")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            var json = File.ReadAllText(Path.Combine(context.FunctionAppDirectory, "data/workaholics.json"));
            var episodes = System.Text.Json.JsonSerializer.Deserialize<Episode[]>(json);
            return new OkObjectResult(episodes);
        }
    }
}
