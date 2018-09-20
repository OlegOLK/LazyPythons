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

        bool IsSomethingFound { get; }
    }
}
