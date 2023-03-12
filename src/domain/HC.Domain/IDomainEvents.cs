using MediatR;
namespace HC.Domain;

public interface IDomainEvents
{
    IEnumerable<INotification> GetDomainEvents();
    void AddDomainEvent(INotification @event);
    void AddDomainEventIfAbsent(INotification @event);
    void ClearDomainEvents();
}