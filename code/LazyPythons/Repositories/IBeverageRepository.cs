using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Models;

namespace LazyPythons.Repositories
{
    public interface IBeverageRepository
    {
        Task<IEnumerable<Beverage>> GetAllBeverages();
        Task<Beverage> GeBeverage(Guid id);
    }
}
