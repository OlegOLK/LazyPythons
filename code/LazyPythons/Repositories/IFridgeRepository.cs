using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Models;

namespace LazyPythons.Repositories
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<IFridgeRecord>> GetPropositions();
        Task<FridgeVoteResponses> VoteForProposition(string positionName, string user);
        Task<FridgeVoteResponses> VoteForProposition(Guid id, string user);
        Task<FridgeAddResponses> AddProposition(string name);
    }
}
