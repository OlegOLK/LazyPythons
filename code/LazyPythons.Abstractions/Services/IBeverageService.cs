using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Abstractions.Services
{
    public interface IBeverageService
    {
        Task<IEnumerable<IBeverage>> GetAllBeverages();
        Task<IBeverage> GeBeverage(Guid id);
    }
}
