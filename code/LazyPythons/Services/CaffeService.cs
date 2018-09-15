using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Abstractions.Services;
using LazyPythons.Repositories;

namespace LazyPythons.Services
{
    public class CaffeService : ICaffeService
    {
        private readonly ICaffeRepository _caffeRepository;
        public CaffeService(ICaffeRepository caffeRepository)
        {
            _caffeRepository = caffeRepository;
        }

        public async Task<IEnumerable<ICaffe>> GetAllCaffes()
        {
            return await _caffeRepository.GetAllCaffes().ConfigureAwait(false);
        }

        public Task<IEnumerable<ICaffe>> GetCaffesInRange(long distance)
        {
            throw new NotImplementedException();
        }

        public Task<ICaffe> GetCaffe(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICaffe> GetCaffe(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ICaffe>> GetCaffesWithFreeBeaverages()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ICaffe>> GetCaffesWithRating(short rating)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ICaffe>> GetCaffesWithLunchPriceLessThan(int price)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ICaffe>> GetCaffesWithLunchPriceMoreThan(int price)
        {
            throw new NotImplementedException();
        }
    }
}
