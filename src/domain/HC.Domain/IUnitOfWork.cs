namespace HC.Domain;

public interface IUnitOfWork
{
    Task CommitAsync();
}