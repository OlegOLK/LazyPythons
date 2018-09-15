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

        public Task<IEnumerable<IDish>> GetAllDishes()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IDish>> GetAllDishesByCategory(DishCategories category)
        {
            throw new NotImplementedException();
        }

        public Task<IDish> GetDish(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
