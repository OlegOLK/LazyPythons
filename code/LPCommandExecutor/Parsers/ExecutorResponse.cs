using System;
using System.Collections.Generic;
using LazyPythons.Abstractions.Models;

namespace LPCommandExecutor.Response
{
    public class ExecutorResponse : IExecutorResponse
    {
        
        public ExecutorResponse(string response)
        {
            this.StringResponse = response;
        }

        public ExecutorResponse(IEnumerable<ICaffe> response)
        {
            this.CafesResponse = response;
        }

        public ExecutorResponse(IEnumerable<IMenu> response)
        {
            this.MenuesResponse = response;
        }

        public string StringResponse
        {
            get;
            private set;
        }

        public IEnumerable<ICaffe> CafesResponse
        {
            get;
            private set;
        }

        public IEnumerable<IMenu> MenuesResponse
        {
            get;
            private set;
        }
    }
}
