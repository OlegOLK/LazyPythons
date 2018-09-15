using LazyPythons.Repositories;
using LazyPythons.Sql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace LazyPythons.Sql.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<LazyPhytonsContext>(options =>
                options.UseSqlServer(connection));

            services.AddTransient<IBeverageRepository, BeverageRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<ICaffeRepository, CaffeRepository>();
            services.AddTransient<IDishRepository, DishRepository>();

            return services;
        }
    }
}
