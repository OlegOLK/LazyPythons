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
    public class MenuRepository : IMenuRepository
    {
        private readonly LazyPhytonsContext _context;
        public MenuRepository(LazyPhytonsContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Menu>> GetAllMenus()
        {
            var result = await _context.Menus.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return result.Select(x => x.ToApi());
        }

        public async Task<Menu> GetMenu(Guid id)
        {
            var result = await _context.Menus.AsNoTracking().FirstOrDefaultAsync(x=> x.Id.Equals(id)).ConfigureAwait(false);
            return result?.ToApi();
        }
    }
}
