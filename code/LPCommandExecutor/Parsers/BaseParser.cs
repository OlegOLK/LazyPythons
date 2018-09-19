using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;

namespace LPCommandExecutor
{
    public class BaseParser : IPhraseProcessor
    {
        protected virtual string RegexStringPattern { get; }

        public BaseParser()
        {
        }

        protected GroupCollection GetParametersList(string command)
        {
            var regex = new Regex(this.RegexStringPattern, RegexOptions.IgnoreCase);
            
            if (!regex.IsMatch(command))
            {
                return null;
            }

            return regex.Match(command).Groups;
        }

        public virtual Task<string> ExecuteCommandAsync(string command, ICaffeService service)
        {
            throw new NotImplementedException();
        }

    }
}
