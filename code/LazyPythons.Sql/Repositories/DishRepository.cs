using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Models;
using LazyPythons.Repositories;
using LazyPythons.Sql.ConfigMappings;
using LazyPythons.Sql.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LazyPythons.Sql.Repositories
{
    public class DishRepository : SqlRepository, IDishRepository
    {
        public DishRepository(DbContextOptions<LazyPhytonsContext> options)
            : base(options)
        {
        }

        public async Task<IEnumerable<Dish>> GetAllDishes()
        {
            List<Data.Dish> dishes = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                dishes = await context.Dishes.AsNoTracking().ToListAsync().ConfigureAwait(false);
            }

            if (dishes == null)
            {
                return Enumerable.Empty<Dish>();
            }

            return dishes.Select(x => x.ToApi());
        }

        public async Task<IEnumerable<Dish>> GetAllDishesByCategory(DishCategories category)
        {
            List<Data.Dish> dishes = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                dishes = await context.Dishes.AsNoTracking().Where(x => x.Category.Equals(category)).ToListAsync()
                    .ConfigureAwait(false);
            }

            if (dishes == null)
            {
                return Enumerable.Empty<Dish>();
            }

            return dishes.Select(x => x.ToApi());
        }

        public async Task<Dish> GetDish(Guid id)
        {
            Data.Dish dish = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                dish = await context.Dishes.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);
            }

            return dish?.ToApi();
        }
    }
}
