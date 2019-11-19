using HereApiIntegration.Adaptors;
using HereApiIntegration.Adaptors.Interfaces;
using HereApiIntegration.Repositories;
using HereApiIntegration.Services;
using HereApiIntegration.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HereApiIntegration.Definitions.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IJsonRouteToGpxAdaptor, JsonRouteToGpxAdaptor>();
            services.AddScoped<IRouteMatchingService, RouteMatchingService>();
            services.AddScoped<ICalculateRouteService, CalculateRouteService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IJsonRouteRepository, JsonRouteRepository>();
        }
    }
}
