using MediatR;
namespace HC.Domain.CargoAggregate.DomainEvent;

public record CargoBookedEvent(string TracingId) : INotification;