using CargoDDD.Domain.CargoAggregate.Repository.Facade;
using CargoDDD.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CargoDDD.Config.ServiceCollectionInjection
{
    public static class RepositoryServiceCollectionInjectionExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ICargoRepository, CargoRepository>();
            return services;
        }
    }
}