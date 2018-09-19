using System;
using System.Collections.Generic;
using System.Text;
using LazyPythons.Sql;
using LazyPythons.Sql.Initialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LazyPythons.Configuration
{
    public static class DataInitializer
    {
        public static void Seed(IServiceProvider provider)
        {
            var options = (DbContextOptions<LazyPhytonsContext>)provider.GetService(typeof(DbContextOptions<LazyPhytonsContext>));
            var sqlInitializer = new SqlInitializer(options);
            sqlInitializer.Initialize();
        }
    }
}
