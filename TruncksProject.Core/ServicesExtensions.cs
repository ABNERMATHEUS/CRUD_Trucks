using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TruncksProject.Core.Contracts;
using TruncksProject.Core.Services;

namespace TruncksProject.Core
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
            services.AddScoped<IServiceTrunck, TrunckService>();

            return services;
        }
    }
}
