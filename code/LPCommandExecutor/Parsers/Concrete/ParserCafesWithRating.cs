using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor
{
    public class ParserCafesWithRating : BaseParser
    {
        protected override string RegexStringPattern => StringConstants.CafesWithRating;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command, ICaffeService service)
        {
            GroupCollection commandParams = this.GetParametersList(command);
            var parameter = commandParams[1].Value;

            var result = await service.GetCaffesWithRating(Convert.ToInt16(parameter)).ConfigureAwait(false);

            return new ExecutorResponse(result);
         }
    }
}
