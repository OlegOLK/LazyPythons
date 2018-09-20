using System;
using System.Collections.Generic;
using System.Text;
using LazyPythons.Abstractions.Models;
using LPCommandExecutor.ViewModels;

namespace LPCommandExecutor.Mappers
{
    public static class MenuViewModelExtensions
    {
        public static MenuViewModel ToViewModel(this IMenu menu, string caffeName, IEnumerable<IDish> dishes, IEnumerable<IBeverage> beverages)
        {
            return new MenuViewModel()
            {
                CaffeName = caffeName,
                LinkToImage = menu.LinkToImage,
                Beverages = beverages,
                Dishes = dishes
            };
        }
    }
}
