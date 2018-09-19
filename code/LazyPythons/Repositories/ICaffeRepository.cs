using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Models;

namespace LazyPythons.Repositories
{
    public interface ICaffeRepository
    {
        Task<IEnumerable<Caffe>> GetAllCaffes();
        Task<IEnumerable<Caffe>> GetCaffesInRange(long distance);
        Task<IEnumerable<ICaffe>> GetCaffesWithFreeBeaverages();
        Task<Caffe> GetCaffe(Guid id);
        Task<Caffe> GetCaffe(string name);
        Task<IEnumerable<ICaffe>> GetCaffesWithLunchPriceLessThan(int price);
        Task<IEnumerable<ICaffe>> GetCaffesWithLunchPriceMoreThan(int price);
        Task<IEnumerable<ICaffe>> GetCaffesWithRating(short rating);
    }
}
