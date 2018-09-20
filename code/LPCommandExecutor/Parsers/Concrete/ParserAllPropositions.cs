using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor.Parsers.Concrete
{
    public class ParserAllPropositions : BaseParser
    {
        private readonly IFridgeService _service;
        public ParserAllPropositions(IFridgeService service)
        {
            _service = service;
        }

        protected override string RegexStringPattern => StringConstants.AllFreedgePositions;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command)
        {
            var regex = new Regex(this.RegexStringPattern, RegexOptions.IgnoreCase);
            if (!regex.IsMatch(command))
            {
                return null;
            }

            var result = await _service.GetPropositions().ConfigureAwait(false);


            return new ExecutorResponse(result);
        }
    }
}
