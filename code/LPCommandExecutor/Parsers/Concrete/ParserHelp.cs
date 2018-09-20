using System;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor
{
    public class ParserHelp : BaseParser
    {
        protected override string RegexStringPattern => StringConstants.Help;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command)
        {
            string result = null;
            if (command.Equals(RegexStringPattern))
            {
                result = StringConstants.HelpResponse;
            }

            return new ExecutorResponse(result);
        }
    }
}
