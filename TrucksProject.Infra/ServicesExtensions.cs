using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TrucksProject.Domain.Repository;
using TrucksProject.Infra.DataContext;
using TrucksProject.Infra.Repository;

namespace TrucksProject.Infra
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataContexts(configuration)
                    .AddRepositories();
            return services;

        }

        private static IServiceCollection AddDataContexts(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Truck;Trusted_Connection=True;"));
            //services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("Database"));
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITruckRepository, TruckRepository>();
            return services;
        }
    }
}
