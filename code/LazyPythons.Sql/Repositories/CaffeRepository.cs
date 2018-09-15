using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Repositories;
using LazyPythons.Sql.Data;
using LazyPythons.Sql.Mappers;
using Microsoft.EntityFrameworkCore;
using Caffe = LazyPythons.Models.Caffe;

namespace LazyPythons.Sql.Repositories
{
    public class CaffeRepository : ICaffeRepository
    {
        private readonly LazyPhytonsContext _context;
        public CaffeRepository(LazyPhytonsContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Caffe>> GetAllCaffes()
        {
            var result = await _context.Caffes.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return result.Select(x => x.ToApi());
        }

        public async Task<Caffe> GetCaffe(Guid id)
        {
            var result = await _context.Caffes.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);
            return result?.ToApi();
        }

        public async Task<Caffe> GetCaffe(string name)
        {
            var result = await _context.Caffes.AsNoTracking().FirstOrDefaultAsync(x => x.Name.Equals(name)).ConfigureAwait(false);
            return result?.ToApi();
        }
    }
}
