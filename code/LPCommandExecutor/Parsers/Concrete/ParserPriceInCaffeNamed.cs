using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor
{
    public class ParserPriceInCaffeNamed : BaseParser
    {
        protected override string RegexStringPattern => StringConstants.PriceInCaffeNamed;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command, ICaffeService service)
        {
            GroupCollection commandParams = this.GetParametersList(command);

            var parameter = commandParams[1].Value;

            //FIXME: @igk hack to avoid compilation error
            await Task.Delay(1);
            //FIXME: not implemented!!!
            return new ExecutorResponse("can not proceed menues");
        }
    }
}
