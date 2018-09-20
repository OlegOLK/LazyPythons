using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor.Parsers.Concrete
{
    public class ParserVoteForProposition : BaseParser
    {
        private readonly IFridgeService _service;
        public ParserVoteForProposition(IFridgeService service)
        {
            _service = service;
        }

        protected override string RegexStringPattern => StringConstants.VoteForPosition;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command, params object[] param)
        {
            GroupCollection commandParams = this.GetParametersList(command);
            var parameter = commandParams[1].Value;
            string user = (string)param[0];
            var result = await _service.VoteForProposition(parameter, user).ConfigureAwait(false);


            return new ExecutorResponse(result);
        }
    }
}
