using System;
using System.Collections.Generic;
using LazyPythons.Abstractions.Models;

namespace LPCommandExecutor.Response
{
    public interface IExecutorResponse
    {
        string StringResponse { get; }
        IEnumerable<ICaffe> CafesResponse { get; }
        IEnumerable<IMenu> MenuesResponse { get; }
    }
}
