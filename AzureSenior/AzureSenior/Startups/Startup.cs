﻿using AzureSenior.Function.Startups;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]
namespace AzureSenior.Function.Startups
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder webJobsBuilder)
        {
            webJobsBuilder = IocConfiguration.ConfigureAll(webJobsBuilder);
            webJobsBuilder.Services.AddMvcCore().AddJsonFormatters();
        }
    }
}
