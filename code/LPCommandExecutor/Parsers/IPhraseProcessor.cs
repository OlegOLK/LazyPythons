using System;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor
{
    public interface IPhraseProcessor
    {
        Task<IExecutorResponse> ExecuteCommandAsync(string command, ICaffeService service);

    }
}
