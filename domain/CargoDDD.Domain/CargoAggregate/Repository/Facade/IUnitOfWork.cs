namespace CargoDDD.Domain.Repository.Facade;
public interface IUnitOfWork : IDisposable
{
    Task<bool> Commit();
}
