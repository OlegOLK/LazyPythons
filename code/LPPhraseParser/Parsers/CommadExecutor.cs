using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPPhraseParser.Errors;

namespace LPPhraseParser
{
    public class CommadExecutor
    {
        private List<IPhraseProcessor> Processors;
        private ICaffeService Service;

        public CommadExecutor(ICaffeService service)
        {
            this.Service = service ?? throw new ArgumentNullException(nameof(service), "CommadExecutor: SERVICE can not be null!");

            Processors = new List<IPhraseProcessor>();
            Processors.Add(new ParserNMinutesToGo());
            Processors.Add(new ParserNMettersToGo());
            Processors.Add(new ParserChipperThanN());
            Processors.Add(new ParserMenuInCaffeNamed());
            Processors.Add(new ParserPriceInCaffeNamed());
            Processors.Add(new ParserRatingForCaffeNamed());
            Processors.Add(new ParserFreeBeverage());
            Processors.Add(new ParserAllCafes());
        }

        public async Task<string> GetResponse(string command)
        {
            string result = null;
            foreach (IPhraseProcessor processor in Processors)
            {
                try
                {
                    result = await processor.ExecuteCommandAsync(command, this.Service);
                }
                catch
                {
                    //do nothing
                }

                if (result != null)
                {
                    return result;
                }
            }

            return StringConstants.CAN_NOT_PARSE_REQUEST;
        }
    }
}
