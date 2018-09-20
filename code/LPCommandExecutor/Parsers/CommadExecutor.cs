using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Response;

namespace LPCommandExecutor
{
    public class CommadExecutor
    {
        private IEnumerable<IPhraseProcessor> Processors;
        //private ICaffeService Service;
        //private readonly IMenuService _menuService;


        public CommadExecutor(IEnumerable<IPhraseProcessor> processors)
        {
            //this.Service = service ?? throw new ArgumentNullException(nameof(service), "CommadExecutor: SERVICE can not be null!");
            //this._menuService = menuService ?? throw new ArgumentNullException(nameof(service), "CommadExecutor: SERVICE can not be null!");


            Processors = processors;
            //Processors.Add(new ParserNMinutesToGo());
            //Processors.Add(new ParserNMettersToGo());
            //Processors.Add(new ParserChipperThanN());
            //Processors.Add(new ParserMenuInCaffeNamed());
            //Processors.Add(new ParserPriceInCaffeNamed());
            //Processors.Add(new ParserCafesWithRating());
            //Processors.Add(new ParserFreeBeverage());
            //Processors.Add(new ParserAllCafes());
        }

        public async Task<IExecutorResponse> GetResponse(string command)
        {
            IExecutorResponse result = null;
            foreach (IPhraseProcessor processor in Processors)
            {
                try
                {
                    result = await processor.ExecuteCommandAsync(command);
                }
                catch (Exception ex)
                {
                    //do nothing
                }

                if (result != null)
                {
                    return result;
                }
            }

            return new ExecutorResponse(StringConstants.CAN_NOT_PARSE_REQUEST);
        }
    }
}
