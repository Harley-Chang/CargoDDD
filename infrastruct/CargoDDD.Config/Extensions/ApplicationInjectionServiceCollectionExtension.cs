using CargoDDD.Application.Service.Facade;
using CargoDDD.Application.Service.Implement;
using Microsoft.Extensions.DependencyInjection;

namespace CargoDDD.Config.ServiceCollectionInjection
{
    public static class ApplicationInjectionServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICargoApplication, CargoApplication>();
            return services;
        }
    }
}
