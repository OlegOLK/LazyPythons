using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Abstractions.Services
{
    public interface IFridgeService
    {
        Task<IEnumerable<IFridgeRecord>> GetPropositions();
        Task<FridgeVoteResponses> VoteForProposition(string positionName, string user);
        Task<FridgeVoteResponses> VoteForProposition(Guid id, string user);
        Task<FridgeAddResponses> AddProposition(string name);
    }
}
