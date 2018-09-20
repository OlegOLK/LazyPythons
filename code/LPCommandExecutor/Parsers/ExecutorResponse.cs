using System;
using System.Collections.Generic;
using System.Linq;
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

        public ExecutorResponse(IEnumerable<IFridgeRecord> response)
        {
            this.FreedgeRecords = response;
        }

        public ExecutorResponse(FridgeAddResponses response)
        {
            this.AddResponses = response;
        }

        public ExecutorResponse(FridgeVoteResponses response)
        {
            this.VoteResponses = response;
        }

        public string StringResponse
        {
            get;
            private set;
        }

        public FridgeVoteResponses VoteResponses
        {
            get;
            private set;
        }

        public FridgeAddResponses AddResponses
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

        public IEnumerable<IFridgeRecord> FreedgeRecords
        {
            get;
            private set;
        }

        public bool IsSomethingFound
        {
            get
            {
                bool voteResponses = (this.VoteResponses  != FridgeVoteResponses.Undefined);    
                bool addResponses = (this.AddResponses  != FridgeAddResponses.Undefined);    
                bool freedgeRecordsAvailable = (this.FreedgeRecords != null && Enumerable.Count(this.FreedgeRecords) > 0);
                bool caffeAvailable = (this.CafesResponse != null && Enumerable.Count(this.CafesResponse) > 0);
                bool menuAvailable = (this.MenuesResponse != null && Enumerable.Count(this.MenuesResponse) > 0);
                bool menuModelsAvailable = (this.MenuViewModels != null && Enumerable.Count(this.MenuViewModels) > 0);

                return 
                    this.StringResponse != null 
                 || caffeAvailable 
                 || menuAvailable 
                 || menuModelsAvailable
                 || voteResponses 
                 || addResponses 
                 || freedgeRecordsAvailable;
            }
        }
    }
}
