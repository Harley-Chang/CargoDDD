using MediatR;
namespace HC.Domain.CargoAggregate.Command;

public record BookCargoCommand(string Name, long Weight, string? HazMatCode, string? Origin, string? Destination) : INotification;
