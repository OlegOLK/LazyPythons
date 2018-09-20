using System;
using System.Collections.Generic;
using System.Text;
using LPCommandExecutor.Parsers.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace LPCommandExecutor.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCommandExecutor(this IServiceCollection services)
        {
            services.AddScoped<IPhraseProcessor, ParserAddProposition>();
            services.AddScoped<IPhraseProcessor, ParserVoteForProposition>();
            services.AddScoped<IPhraseProcessor, ParserAllPropositions>();

            services.AddScoped<IPhraseProcessor, ParserNMinutesToGo>();
            services.AddScoped<IPhraseProcessor, ParserNMettersToGo>();
            services.AddScoped<IPhraseProcessor, ParserChipperThanN>();
            services.AddScoped<IPhraseProcessor, ParserMenuInCaffeNamed>();
            services.AddScoped<IPhraseProcessor, ParserPriceInCaffeNamed>();
            services.AddScoped<IPhraseProcessor, ParserCafesWithRating>();
            services.AddScoped<IPhraseProcessor, ParserFreeBeverage>();
            services.AddScoped<IPhraseProcessor, ParserAllCafes>();

            services.AddScoped<CommadExecutor, CommadExecutor>();

            return services;
        }
    }
}
