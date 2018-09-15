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
        Task<Caffe> GetCaffe(Guid id);
        Task<Caffe> GetCaffe(string name);
    }
}
