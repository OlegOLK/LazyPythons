using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

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

        public virtual Task<IExecutorResponse> ExecuteCommandAsync(string command, ICaffeService service)
        {
            throw new NotImplementedException();
        }

    }
}
