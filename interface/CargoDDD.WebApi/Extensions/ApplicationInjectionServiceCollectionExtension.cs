using CargoDDD.Application.Service.Facade;
using CargoDDD.Application.Service.Implement;

namespace CargoDDD.WebApi.Extensions
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
