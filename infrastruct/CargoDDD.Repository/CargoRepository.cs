using CargoDDD.Domain.CargoAggregate.Repository;

namespace CargoDDD.Repository
{
    public class CargoRepository : ICargoRepository
    {
        public Task AddAsync(object entity)
        {
            throw new NotImplementedException();
        }
    }
}