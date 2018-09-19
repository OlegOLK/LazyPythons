using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LazyPythons.Sql.Repositories
{
    public abstract class SqlRepository
    {
        private readonly DbContextOptions<LazyPhytonsContext> _settings;
        protected SqlRepository(DbContextOptions<LazyPhytonsContext> settings)
        {
            _settings = settings;
        }

        protected virtual LazyPhytonsContext CreateLazyPhytonsContext()
        {
            return new LazyPhytonsContext(_settings);
        }

    }
}
