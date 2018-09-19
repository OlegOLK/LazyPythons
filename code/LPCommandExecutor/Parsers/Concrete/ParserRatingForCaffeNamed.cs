using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Errors;

namespace LPCommandExecutor
{
    public class ParserRatingForCaffeNamed : BaseParser
    {
        protected override string RegexStringPattern => StringConstants.RatingForCaffeNamed;

        public override async Task<string> ExecuteCommandAsync(string command, ICaffeService service)
        {
            GroupCollection commandParams = this.GetParametersList(command);

            var parameter = commandParams[1].Value;

            //FIXME: @igk hack to avoid compilation error
            await Task.Delay(1);

            return "result parameter " + parameter;
        }
    }
}
