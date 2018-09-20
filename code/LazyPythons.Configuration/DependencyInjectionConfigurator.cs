using System;
using LazyPythons.Extensions;
using Microsoft.Extensions.Configuration;
using LazyPythons.Sql.Extensions;
using LPCommandExecutor.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace LazyPythons.Configuration
{
    public static class DependencyInjectionConfigurator
    {
        public static IServiceCollection UseConfigurator(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServices();
            services.RegisterRepositories(configuration);
            services.RegisterCommandExecutor();
            return services;
        }
    }
}
