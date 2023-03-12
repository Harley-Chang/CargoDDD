using MediatR;

namespace HC.Domain;

public class BaseEntity : IDomainEvents
{
    public Guid Id { get; set; }
    public DateTimeOffset? CreatedOn { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
    public string? LastModifiedBy { get; set; }

    private IList<INotification> _domainEvents;
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        _domainEvents = new List<INotification>();
    }

    public void AddDomainEvent(INotification @event)
    {
        _domainEvents.Add(@event);
    }

    public void AddDomainEventIfAbsent(INotification @event)
    {
        if (!_domainEvents.Contains(@event))
        {
            AddDomainEvent(@event);
        }
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public IEnumerable<INotification> GetDomainEvents()
    {
        return _domainEvents;
    }
}