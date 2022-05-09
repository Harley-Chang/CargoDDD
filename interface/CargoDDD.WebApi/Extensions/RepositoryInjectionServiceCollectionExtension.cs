using CargoDDD.Domain.CargoAggregate.Repository;
using CargoDDD.Repository;

namespace CargoDDD.WebApi.Extensions
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