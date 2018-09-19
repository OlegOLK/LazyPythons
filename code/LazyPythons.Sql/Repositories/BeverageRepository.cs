using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyPythons.Models;
using LazyPythons.Repositories;
using LazyPythons.Sql.ConfigMappings;
using LazyPythons.Sql.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LazyPythons.Sql.Repositories
{
    public class BeverageRepository : SqlRepository, IBeverageRepository
    {
        public BeverageRepository(DbContextOptions<LazyPhytonsContext> options)
            : base(options)
        {
        }

        public async Task<IEnumerable<Beverage>> GetAllBeverages()
        {
            List<Data.Beverage> beverages = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                beverages = await context.Beverages.AsNoTracking().ToListAsync().ConfigureAwait(false);
            }

            if (beverages == null)
            {
                return Enumerable.Empty<Beverage>();
            }

            return beverages.Select(x => x.ToApi());
        }

        public async Task<Beverage> GeBeverage(Guid id)
        {
            Data.Beverage beverage = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                beverage = await context.Beverages.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);
            }

            return beverage?.ToApi();
        }
    }
}
