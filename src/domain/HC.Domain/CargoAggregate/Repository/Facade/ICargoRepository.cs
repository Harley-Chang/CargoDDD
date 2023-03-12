using HC.Domain.CargoAggregate.Entity;

namespace HC.Domain.CargoAggregate.Repository;
public interface ICargoRepository
{
    Task AddAsync(Cargo entity);
}
