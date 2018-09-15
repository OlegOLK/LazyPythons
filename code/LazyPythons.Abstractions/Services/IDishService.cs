using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Abstractions.Services
{
    public interface IDishService
    {
        Task<IEnumerable<IDish>> GetAllDishes();
        Task<IEnumerable<IDish>> GetAllDishesByCategory(DishCategories category);
        Task<IDish> GetDish(Guid id);
    }
}
