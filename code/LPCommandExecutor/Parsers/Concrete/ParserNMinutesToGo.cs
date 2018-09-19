using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Errors;

namespace LPCommandExecutor
{
    public class ParserNMinutesToGo : BaseParser
    {
        protected override string RegexStringPattern => StringConstants.NMinutesToGo;

        public override async Task<string> ExecuteCommandAsync(string command, ICaffeService service)
        {
            GroupCollection commandParams = this.GetParametersList(command);

            var parameter = commandParams[1].Value;

            //FIXME: @igk magik number 80 - meters per minute speed
            var result = await service.GetCaffesInRange(Convert.ToInt32(parameter)/80).ConfigureAwait(false);
            var t = result.Select(x => x.Name).ToList();

            return "result: " + t.ToString();
        }
    }
}
