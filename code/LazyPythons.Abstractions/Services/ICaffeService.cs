using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;

namespace LazyPythons.Abstractions.Services
{
    public interface ICaffeService
    {
        Task<IEnumerable<ICaffe>> GetAllCaffes();
        Task<IEnumerable<ICaffe>> GetCaffesInRange(long distance);
        Task<ICaffe> GetCaffe(Guid id);
        Task<ICaffe> GetCaffe(string name);
        Task<IEnumerable<ICaffe>> GetCaffesWithFreeBeaverages();
        Task<IEnumerable<ICaffe>> GetCaffesWithRating(short rating);
        Task<IEnumerable<ICaffe>> GetCaffesWithLunchPriceLessThan(int price);
        Task<IEnumerable<ICaffe>> GetCaffesWithLunchPriceMoreThan(int price);
    }
}
