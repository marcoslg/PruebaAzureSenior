using AzureFunction.Contracts;
using AzureSenior.Impl;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureSenior.Function.Startups
{
    public static class IocConfiguration
    {
        public static IWebJobsBuilder ConfigureAll(IWebJobsBuilder webJobsBuilder)
        {
            webJobsBuilder.Services.AddServices();
            return webJobsBuilder;
        }       

        private static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(x => new ConfigurationBuilder()
                .SetBasePath(System.Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build());

            serviceCollection.AddSingleton<IWelcomeService, WelcomeService>();
            
        }
    }
}
