namespace CargoDDD.Domain.CustomerAggregate.Repository.Facade;
public interface ICustomerRepository<TEntity> : IDisposable where TEntity : class
{
    Task AddAsync(TEntity entity);
    TEntity GetByIdAsync(Guid id);
    IQueryable<TEntity> GetAllAsync();
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(Guid id);
    Task<int> SaveChangesAsync();
}
