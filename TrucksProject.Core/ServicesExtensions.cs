using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrucksProject.Core.Contracts;
using TrucksProject.Core.Services;

namespace TrucksProject.Core
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddService();                    
            return services;

        }

        private static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IServiceTruck, TruckService>();

            return services;
        }
    }
}
