using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HC.Domain;

public abstract class BaseDbContext : DbContext
{
    private IMediator _mediator;
    public BaseDbContext(DbContextOptions options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        PublishDomainEvents().GetAwaiter().GetResult();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public async override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        await PublishDomainEvents();
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private async Task PublishDomainEvents()
    {
        var domainEntities = ChangeTracker.Entries<IDomainEvents>().Where(s => s.Entity.GetDomainEvents().Any());
        var domainEvents = domainEntities.SelectMany(s => s.Entity.GetDomainEvents()).ToList();
        domainEntities.ToList().ForEach(s => s.Entity.ClearDomainEvents());
        foreach (var @event in domainEvents)
        {
            await _mediator.Publish(@event);
        }
    }
}