using HC.Application.Service.Facade;
using HC.Application.Service.Implement;
using Microsoft.Extensions.DependencyInjection;

namespace HC.Config.ServiceCollectionInjection
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
