using System;
using System.Threading.Tasks;

namespace AzureFunction.Contracts
{
    public interface IWelcomeService
    {
        Task<string> GetWelcome();
    }
}
