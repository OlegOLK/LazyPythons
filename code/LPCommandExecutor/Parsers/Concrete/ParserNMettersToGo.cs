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
        private readonly ICaffeService _service;
        public ParserNMettersToGo(ICaffeService service)
        {
            _service = service;
        }

        protected override string RegexStringPattern => StringConstants.NMettersToGo;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command)
        {
            GroupCollection commandParams = this.GetParametersList(command);
            var parameter = commandParams[1].Value;

            var result = await _service.GetCaffesInRange(Convert.ToInt32(parameter)).ConfigureAwait(false);

            return new ExecutorResponse(result);
        }
    }
}
