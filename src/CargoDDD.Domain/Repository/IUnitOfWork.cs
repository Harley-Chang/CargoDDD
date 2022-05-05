namespace CargoDDD.Domain.Repository;
public interface IUnitOfWork : IDisposable
{
    Task<bool> Commit();
}
