using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TruncksProject.Domain.Repository;
using TruncksProject.Infra.DataContext;
using TruncksProject.Infra.Repository;

namespace TruncksProject.Infra
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
            //services.AddDbContext<Context>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Trunck;Trusted_Connection=True;"));
            services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("Database"));
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITrunckRepository, TrunckRepository>();
            return services;
        }
    }
}
