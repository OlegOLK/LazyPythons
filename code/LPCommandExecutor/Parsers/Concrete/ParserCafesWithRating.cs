using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor
{
    public class ParserCafesWithRating : BaseParser
    {
        private readonly ICaffeService _service;
        public ParserCafesWithRating(ICaffeService service)
        {
            _service = service;
        }

        protected override string RegexStringPattern => StringConstants.CafesWithRating;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command)
        {
            GroupCollection commandParams = this.GetParametersList(command);
            var parameter = commandParams[1].Value;

            var result = await _service.GetCaffesWithRating(Convert.ToInt16(parameter)).ConfigureAwait(false);

            return new ExecutorResponse(result);
         }
    }
}
