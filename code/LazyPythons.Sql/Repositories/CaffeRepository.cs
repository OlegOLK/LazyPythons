using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Repositories;
using LazyPythons.Sql.ConfigMappings;
using LazyPythons.Sql.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Caffe = LazyPythons.Models.Caffe;

namespace LazyPythons.Sql.Repositories
{
    public class CaffeRepository : SqlRepository, ICaffeRepository
    {
        public CaffeRepository(DbContextOptions<LazyPhytonsContext> options)
            : base(options)
        {
        }


        public async Task<IEnumerable<Caffe>> GetAllCaffes()
        {
            List<Data.Caffe> caffes = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                caffes = await context.Caffes.AsNoTracking().ToListAsync().ConfigureAwait(false);
            }

            if (caffes == null)
            {
                return Enumerable.Empty<Caffe>();
            }

            return caffes.Select(x => x.ToApi());
        }

        public async Task<IEnumerable<Caffe>> GetCaffesInRange(long distance)
        {
            List<Data.Caffe> caffes = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                caffes = await context.Caffes.AsNoTracking().Where(x => x.DistanceFromOffice <= distance).ToListAsync().ConfigureAwait(false);
            }

            if (caffes == null)
            {
                return Enumerable.Empty<Caffe>();
            }

            return caffes.Select(x => x.ToApi());
        }

        public async Task<IEnumerable<ICaffe>> GetCaffesWithFreeBeaverages()
        {
            List<Data.Caffe> caffes = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                caffes = await context.Caffes.AsNoTracking().Where(x => x.IsFreeBeverages).ToListAsync().ConfigureAwait(false);
            }

            if (caffes == null)
            {
                return Enumerable.Empty<Caffe>();
            }

            return caffes.Select(x => x.ToApi());
        }

        public async Task<Caffe> GetCaffe(Guid id)
        {
            Data.Caffe caffe = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                caffe = await context.Caffes.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);
            }

            return caffe?.ToApi();
        }

        public async Task<Caffe> GetCaffe(string name)
        {
            Data.Caffe caffe = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                caffe = await context.Caffes.AsNoTracking().FirstOrDefaultAsync(x => x.Name.Equals(name)).ConfigureAwait(false);
            }

            return caffe?.ToApi();
        }

        public async Task<IEnumerable<ICaffe>> GetCaffesWithLunchPriceLessThan(int price)
        {
            List<Data.Caffe> caffes = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                caffes = await context.Caffes.AsNoTracking().Where(x => x.Lunch3Price <= price).ToListAsync().ConfigureAwait(false);
            }

            if (caffes == null)
            {
                return Enumerable.Empty<Caffe>();
            }

            return caffes.Select(x => x.ToApi());
        }

        public async Task<IEnumerable<ICaffe>> GetCaffesWithLunchPriceMoreThan(int price)
        {
            List<Data.Caffe> caffes = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                caffes = await context.Caffes.AsNoTracking().Where(x => x.Lunch3Price > price).ToListAsync().ConfigureAwait(false);
            }

            if (caffes == null)
            {
                return Enumerable.Empty<Caffe>();
            }

            return caffes.Select(x => x.ToApi());
        }

        public async Task<IEnumerable<ICaffe>> GetCaffesWithRating(short rating)
        {
            List<Data.Caffe> caffes = null;
            using (LazyPhytonsContext context = CreateLazyPhytonsContext())
            {
                caffes = await context.Caffes.AsNoTracking().Where(x => x.Rating == rating).ToListAsync().ConfigureAwait(false);
            }

            if (caffes == null)
            {
                return Enumerable.Empty<Caffe>();
            }

            return caffes.Select(x => x.ToApi());
        }

    }
}
