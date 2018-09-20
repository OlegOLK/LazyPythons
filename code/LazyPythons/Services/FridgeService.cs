using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Abstractions.Services;
using LazyPythons.Repositories;

namespace LazyPythons.Services
{
    public class FridgeService : IFridgeService
    {
        private readonly IFridgeRepository _repository;
        public FridgeService(IFridgeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IFridgeRecord>> GetPropositions()
        {
            return await _repository.GetPropositions().ConfigureAwait(false);
        }

        public async Task<FridgeVoteResponses> VoteForProposition(string positionName, string user)
        {
            return await _repository.VoteForProposition(positionName, user).ConfigureAwait(false);
        }

        public async Task<FridgeVoteResponses> VoteForProposition(Guid id, string user)
        {
            return await _repository.VoteForProposition(id, user).ConfigureAwait(false);
        }

        public async Task<FridgeAddResponses> AddProposition(string name)
        {
            return await _repository.AddProposition(name).ConfigureAwait(false);
        }
    }
}
