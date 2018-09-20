using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Abstractions.Services;
using LazyPythons.Repositories;

namespace LazyPythons.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<IMenu>> GetAllMenus()
        {
            return await _menuRepository.GetAllMenus().ConfigureAwait(false);
        }

        public async Task<IMenu> GetMenu(Guid id)
        {
            return await _menuRepository.GetMenu(id).ConfigureAwait(false);
        }

        public async Task<IMenu> GetMenuByCaffeId(Guid id)
        {
            return await _menuRepository.GetMenuByCaffeId(id).ConfigureAwait(false);
        }
    }
}
