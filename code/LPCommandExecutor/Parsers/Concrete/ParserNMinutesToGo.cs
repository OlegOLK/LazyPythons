using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor
{
    public class ParserNMinutesToGo : BaseParser
    {

        private readonly ICaffeService _service;
        public ParserNMinutesToGo(ICaffeService service)
        {
            _service = service;
        }
        protected override string RegexStringPattern => StringConstants.NMinutesToGo;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command)
        {
            GroupCollection commandParams = this.GetParametersList(command);

            var parameter = commandParams[1].Value;

            //FIXME: @igk magik number 80 - meters per minute speed
            var result = await _service.GetCaffesInRange(Convert.ToInt32(parameter)*80).ConfigureAwait(false);

            return new ExecutorResponse(result);
        }
    }
}
