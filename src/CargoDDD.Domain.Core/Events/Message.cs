using MediatR;

namespace CargoDDD.Domain.Core.Events;
public class Message : IRequest<bool>
{
    public string? MessageType { get; protected set; }
    public string? AggregateId { get; protected set; }

    protected Message()
    {
        MessageType = GetType().Name;
    }
}
