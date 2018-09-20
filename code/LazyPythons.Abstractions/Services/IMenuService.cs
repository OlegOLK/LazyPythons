using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Abstractions.Services
{
    public interface IMenuService
    {
        Task<IEnumerable<IMenu>> GetAllMenus();
        Task<IMenu> GetMenu(Guid id);
        Task<IMenu> GetMenuByCaffeId(Guid id);
    }
}
