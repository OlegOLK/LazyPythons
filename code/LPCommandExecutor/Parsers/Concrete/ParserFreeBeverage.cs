using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor
{
    public class ParserFreeBeverage : BaseParser
    {
        private readonly ICaffeService _service;
        public ParserFreeBeverage(ICaffeService service)
        {
            _service = service;
        }

        protected override string RegexStringPattern => StringConstants.FreeBeverage;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command)
        {
            var regex = new Regex(this.RegexStringPattern, RegexOptions.IgnoreCase);
            if (!regex.IsMatch(command))
            {
                return null;
            }

            var result = await _service.GetCaffesWithFreeBeaverages().ConfigureAwait(false);

            return new ExecutorResponse(result);
         }
    }
}
