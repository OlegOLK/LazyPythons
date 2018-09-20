using System;
using System.Collections.Generic;
using LazyPythons.Abstractions.Models;
using LPCommandExecutor.ViewModels;

namespace LPCommandExecutor.Response
{
    public interface IExecutorResponse
    {
        string StringResponse { get; }
        IEnumerable<ICaffe> CafesResponse { get; }
        IEnumerable<IMenu> MenuesResponse { get; }
        IEnumerable<MenuViewModel> MenuViewModels { get; }

        IEnumerable<IFridgeRecord> FreedgeRecords { get; }
        FridgeVoteResponses VoteResponses { get; }
        FridgeAddResponses AddResponses { get; }
        bool IsSomethingFound { get; }
    }
}
