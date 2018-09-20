using System;
using System.Collections.Generic;
using System.Text;
using LazyPythons.Abstractions.Services;
using LazyPythons.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LazyPythons.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IFridgeService, FridgeService>();
            services.AddTransient<IBeverageService, BeverageService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<ICaffeService, CaffeService>();
            services.AddTransient<IDishService, DishService>();

            return services;
        }
    }
}
