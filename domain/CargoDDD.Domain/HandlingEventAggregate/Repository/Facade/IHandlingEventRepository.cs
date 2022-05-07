namespace CargoDDD.Domain.HandlingEventAggregate.Repository.Facade;
public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    Task AddAsync(TEntity entity);
    TEntity GetByIdAsync(Guid id);
    IQueryable<TEntity> GetAllAsync();
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(Guid id);
    Task<int> SaveChangesAsync();
}
