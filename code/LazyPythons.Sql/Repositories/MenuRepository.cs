using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyPythons.Models;
using LazyPythons.Repositories;
using LazyPythons.Sql.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LazyPythons.Sql.Repositories
{
    public class MenuRepository : SqlRepository, IMenuRepository
    {
        public MenuRepository(DbContextOptions<LazyPhytonsContext> options)
            : base(options)
        {
        }

        public async Task<IEnumerable<Menu>> GetAllMenus()
        {
            List<Data.Menu> menus = null;
            using (var context = CreateLazyPhytonsContext())
            {
                menus = await context.Menus.AsNoTracking().ToListAsync().ConfigureAwait(false);
            }

            if (menus == null)
            {
                return Enumerable.Empty<Menu>();
            }

            return menus.Select(x => x.ToApi());
        }

        public async Task<Menu> GetMenu(Guid id)
        {
            Data.Menu menu = null;
            using (var context = CreateLazyPhytonsContext())
            {
                menu = await context.Menus.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);
            }

            return menu?.ToApi();
        }

        public async Task<Menu> GetMenuByCaffeId(Guid id)
        {
            Data.Menu menu = null;
            using (var context = CreateLazyPhytonsContext())
            {
                menu = await context.Menus.AsNoTracking().FirstOrDefaultAsync(x => x.CaffeId.Equals(id)).ConfigureAwait(false);
            }

            return menu?.ToApi();
        }
    }
}
