using System;
using AutoMapper;
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
            services.AddScoped(options =>
                {
                    var optionsBuilder = new DbContextOptionsBuilder<LazyPhytonsContext>();
                    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                    return optionsBuilder.Options;
                });
            
            services.AddTransient<IBeverageRepository, BeverageRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<ICaffeRepository, CaffeRepository>();
            services.AddTransient<IDishRepository, DishRepository>();
            ConfigureAutoMapper();

            return services;
        }

        public static void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<LazyPythons.Sql.Data.Menu, LazyPythons.Models.Menu>();
                cfg.CreateMap<LazyPythons.Models.Menu, LazyPythons.Sql.Data.Menu>();
                cfg.CreateMap<LazyPythons.Sql.Data.Caffe, LazyPythons.Models.Caffe>();
                cfg.CreateMap<LazyPythons.Models.Caffe, LazyPythons.Sql.Data.Caffe>();
                cfg.CreateMap<LazyPythons.Models.Dish, LazyPythons.Sql.Data.Dish>();
                cfg.CreateMap<LazyPythons.Sql.Data.Dish, LazyPythons.Models.Dish>();
                cfg.CreateMap<LazyPythons.Sql.Data.Beverage, LazyPythons.Models.Beverage>();
                cfg.CreateMap<LazyPythons.Models.Beverage, LazyPythons.Sql.Data.Beverage>();
            });
        }
    }
}
