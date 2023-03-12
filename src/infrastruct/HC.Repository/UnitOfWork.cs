using HC.Domain;

namespace HC.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly BaseDbContext _context;
    public UnitOfWork(BaseDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync(true);
    }
}