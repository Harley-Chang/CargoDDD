namespace CargoDDD.Domain.CargoAggregate.Repository.Facade;
public interface ICargoRepository
{
    Task AddAsync(object entity);
}
