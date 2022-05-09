using CargoDDD.Application.Service;

namespace CargoDDD.WebApi.Extensions
{
    public static class ApplicationInjectionServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICargoTrafficApplication, CargoTrafficApplication>();
            return services;
        }
    }
}
