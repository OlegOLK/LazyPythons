using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Models;
using LazyPythons.Repositories;
using LazyPythons.Sql.Mappers;
using Microsoft.EntityFrameworkCore;

namespace LazyPythons.Sql.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly LazyPhytonsContext _context;
        public DishRepository(LazyPhytonsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dish>> GetAllDishes()
        {
            var result = await _context.Dishes.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return result.Select(x => x.ToApi());
        }

        public async Task<IEnumerable<Dish>> GetAllDishesByCategory(DishCategories category)
        {
            var result = await _context.Dishes.AsNoTracking().Where(x=> x.Category.Equals(category)).ToListAsync().ConfigureAwait(false);
            return result.Select(x => x.ToApi());
        }

        public async Task<Dish> GetDish(Guid id)
        {
            var result = await _context.Dishes.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);
            return result?.ToApi();
        }
    }
}
