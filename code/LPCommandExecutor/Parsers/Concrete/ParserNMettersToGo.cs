using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor
{
    public class ParserNMettersToGo : BaseParser
    {
        protected override string RegexStringPattern => StringConstants.NMettersToGo;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command, ICaffeService service)
        {
            GroupCollection commandParams = this.GetParametersList(command);
            var parameter = commandParams[1].Value;

            var result = await service.GetCaffesInRange(Convert.ToInt32(parameter)).ConfigureAwait(false);

            return new ExecutorResponse(result);
        }
    }
}
