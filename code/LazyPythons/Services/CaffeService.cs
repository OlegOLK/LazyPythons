using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<ICaffe>> GetCaffesInRange(long distance)
        {
            return await _caffeRepository.GetCaffesInRange(distance).ConfigureAwait(false);
        }

        public async Task<ICaffe> GetCaffe(Guid id)
        {
            return await _caffeRepository.GetCaffe(id).ConfigureAwait(false);
        }

        public async Task<ICaffe> GetCaffe(string name)
        {
            return await _caffeRepository.GetCaffe(name).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ICaffe>> GetCaffesWithFreeBeaverages()
        {
            return await _caffeRepository.GetCaffesWithFreeBeaverages().ConfigureAwait(false);
        }

        public async Task<IEnumerable<ICaffe>> GetCaffesWithRating(short rating)
        {
            return await _caffeRepository.GetCaffesWithRating(rating).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ICaffe>> GetCaffesWithLunchPriceLessThan(int price)
        {
            return await _caffeRepository.GetCaffesWithLunchPriceLessThan(price).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ICaffe>> GetCaffesWithLunchPriceMoreThan(int price)
        {
            return await _caffeRepository.GetCaffesWithLunchPriceMoreThan(price).ConfigureAwait(false);
        }
    }
}
