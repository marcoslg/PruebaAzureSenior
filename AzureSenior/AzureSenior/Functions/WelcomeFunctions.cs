using AzureFunction.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureSenior
{
    public class WelcomeFunctions
    {
        private readonly IWelcomeService _welcomeService;
        public WelcomeFunctions(IWelcomeService welcomeService)
        {
            _welcomeService = welcomeService;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var strWelcome = await _welcomeService.GetWelcome();

            return strWelcome != null
                ? (ActionResult)new OkObjectResult(strWelcome)
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
