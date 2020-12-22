using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using BlazorApp.Shared;

namespace BlazorApp.Api
{
    public static class EpisodeFunctions
    {
        private static string GetEpisode(int temp)
        {
            return "";
        }

        [FunctionName("Episodes")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var json = System.IO.File.ReadAllText("data/workaholics.json");
            var episodes = System.Text.Json.JsonSerializer.Deserialize<Episode[]>(json);
            return new OkObjectResult(episodes);
        }
    }
}
