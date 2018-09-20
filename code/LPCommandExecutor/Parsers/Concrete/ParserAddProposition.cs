using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor.Parsers.Concrete
{
    public class ParserAddProposition : BaseParser
    {
        private readonly IFridgeService _service;
        public ParserAddProposition(IFridgeService service)
        {
            _service = service;
        }

        protected override string RegexStringPattern => StringConstants.AddPosition;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command)
        {
            GroupCollection commandParams = this.GetParametersList(command);
            var parameter = commandParams[1].Value;

            var result = await _service.AddProposition(parameter).ConfigureAwait(false);

            return new ExecutorResponse(result);
        }
    }
}
