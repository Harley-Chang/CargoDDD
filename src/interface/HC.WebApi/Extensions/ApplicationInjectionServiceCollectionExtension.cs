using HC.Application.Service;

namespace HC.WebApi.Extensions
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
