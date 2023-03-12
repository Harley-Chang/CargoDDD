using HC.Domain.CargoAggregate.Repository.Facade;
using HC.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace HC.Config.ServiceCollectionInjection
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