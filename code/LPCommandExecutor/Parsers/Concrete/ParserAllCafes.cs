using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor
{
    public class ParserAllCafes : BaseParser
    {
        private readonly ICaffeService _service;
        public ParserAllCafes(ICaffeService service)
        {
            _service = service;
        }

        protected override string RegexStringPattern => StringConstants.AllCafes;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command)
        {
            var regex = new Regex(this.RegexStringPattern, RegexOptions.IgnoreCase);
            if (!regex.IsMatch(command))
            {
                return null;
            }

            var result = await _service.GetAllCaffes().ConfigureAwait(false);
          

            return new ExecutorResponse(result);
        }
    }
}
