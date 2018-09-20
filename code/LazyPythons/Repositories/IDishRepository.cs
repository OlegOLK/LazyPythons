using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Models;

namespace LazyPythons.Repositories
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetAllDishes();
        Task<IEnumerable<Dish>> GetAllDishesByCategory(DishCategories category);
        Task<Dish> GetDish(Guid id);
        Task<IEnumerable<Dish>> GetAllDishesByMenuId(Guid menuId);
    }
}
