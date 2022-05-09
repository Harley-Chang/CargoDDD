namespace CargoDDD.Domain.CargoAggregate.Repository;
public interface ICargoRepository
{
    Task AddAsync(object entity);
}
