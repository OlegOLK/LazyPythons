using System;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;

namespace LPPhraseParser
{
    public interface IPhraseProcessor
    {
        Task<string> ExecuteCommandAsync(string command, ICaffeService service);

    }
}
