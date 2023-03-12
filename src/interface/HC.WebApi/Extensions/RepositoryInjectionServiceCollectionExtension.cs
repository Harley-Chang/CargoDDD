using HC.Domain.CargoAggregate.Repository;
using HC.Repository;
using HC.Domain;

namespace HC.WebApi.Extensions
{
    public static class RepositoryServiceCollectionInjectionExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}