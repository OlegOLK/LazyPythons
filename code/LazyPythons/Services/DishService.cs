using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Abstractions.Services;
using LazyPythons.Repositories;

namespace LazyPythons.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;
        public DishService(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public async Task<IEnumerable<IDish>> GetAllDishes()
        {
            return await _dishRepository.GetAllDishes().ConfigureAwait(false);
        }

        public async Task<IEnumerable<IDish>> GetAllDishesByCategory(DishCategories category)
        {
            return await _dishRepository.GetAllDishesByCategory(category).ConfigureAwait(false);
        }

        public async Task<IDish> GetDish(Guid id)
        {
            return await _dishRepository.GetDish(id).ConfigureAwait(false);
        }
    }
}
