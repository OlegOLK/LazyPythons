using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Models;

namespace LazyPythons.Repositories
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetAllMenus();
        Task<Menu> GetMenu(Guid id);
        Task<Menu> GetMenuByCaffeId(Guid id);
    }
}
