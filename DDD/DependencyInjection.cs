using DAL;
using Kernel;
using Kernel.Entities;
using Kernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

namespace DDD
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuration de la base de données
            services.AddDbContext<DataContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));

            // Ajout des services et des interfaces
            services.AddSingleton<IDAL, MainDatabase>();

            return services;
        }
    }
}
