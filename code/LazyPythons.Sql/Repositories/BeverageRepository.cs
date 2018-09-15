using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyPythons.Models;
using LazyPythons.Repositories;
using LazyPythons.Sql.Mappers;
using Microsoft.EntityFrameworkCore;

namespace LazyPythons.Sql.Repositories
{
    public class BeverageRepository : IBeverageRepository
    {
        private readonly LazyPhytonsContext _context;
        public BeverageRepository(LazyPhytonsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beverage>> GetAllBeverages()
        {
            var result = await _context.Beverages.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return result.Select(x => x.ToApi());
        }

        public async Task<Beverage> GeBeverage(Guid id)
        {
            var result = await _context.Beverages.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);
            return result?.ToApi();
        }
    }
}
