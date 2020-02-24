using AzureFunction.Contracts;
using System;
using System.Threading.Tasks;

namespace AzureSenior.Impl
{
    public class WelcomeService : IWelcomeService
    {
        public Task<string> GetWelcome() => Task.FromResult("Hello world!");
    }
}
