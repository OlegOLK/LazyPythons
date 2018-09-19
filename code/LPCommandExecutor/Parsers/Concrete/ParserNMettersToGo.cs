using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Errors;

namespace LPCommandExecutor
{
    public class ParserNMettersToGo : BaseParser
    {
        protected override string RegexStringPattern => StringConstants.NMettersToGo;

        public override async Task<string> ExecuteCommandAsync(string command, ICaffeService service)
        {
            GroupCollection commandParams = this.GetParametersList(command);
            var parameter = commandParams[1].Value;

            var result = await service.GetCaffesInRange(Convert.ToInt32(parameter)).ConfigureAwait(false);
            var t = result.Select(x => x.Name).ToList();

            return "result: " + t.ToString();
        }
    }
}
