using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Abstractions.Services;
using LazyPythons.Repositories;

namespace LazyPythons.Services
{
    public class BeverageService : IBeverageService
    {
        private readonly IBeverageRepository _beverageRepository;
        public BeverageService(IBeverageRepository beverageRepository)
        {
            _beverageRepository = beverageRepository;
        }

        public async Task<IEnumerable<IBeverage>> GetAllBeverages()
        {
            return await _beverageRepository.GetAllBeverages().ConfigureAwait(false);
        }

        public async Task<IBeverage> GeBeverage(Guid id)
        {
            return await _beverageRepository.GeBeverage(id).ConfigureAwait(false);
        }
    }
}
