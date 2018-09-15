using System;
using System.Collections.Generic;
using System.Text;
using LazyPythons.Sql;
using LazyPythons.Sql.Initialization;

namespace LazyPythons.Configuration
{
    public static class DataInitializer
    {
        public static void Seed(IServiceProvider provider)
        {
            LazyPhytonsContext context = (LazyPhytonsContext)provider.GetService(typeof(LazyPhytonsContext));
            var sqlInitializer = new SqlInitializer(context);
            sqlInitializer.Initialize();
        }
    }
}
