using System;
using System.Collections.Generic;
using LazyPythons.Abstractions.Models;
using LPCommandExecutor.ViewModels;

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

        public ExecutorResponse(IEnumerable<MenuViewModel> response)
        {
            this.MenuViewModels = response;
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

        public IEnumerable<MenuViewModel> MenuViewModels
        {
            get;
            private set;
        }

        public bool IsSomethingFound
        {
            get
            {
                return this.StringResponse != null || this.CafesResponse != null || this.MenuesResponse != null || this.MenuViewModels !=null;
            }
        }
    }
}
