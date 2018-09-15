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

        public Task<IEnumerable<IMenu>> GetAllMenus()
        {
            throw new NotImplementedException();
        }

        public Task<IMenu> GetMenu(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
