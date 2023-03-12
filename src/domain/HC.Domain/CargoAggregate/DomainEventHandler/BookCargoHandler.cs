using HC.Domain.CargoAggregate.Command;
using HC.Domain.CargoAggregate.Entity;
using HC.Domain.CargoAggregate.Repository;
using HC.Domain.CargoAggregate.ValueObject;
using MediatR;

namespace HC.Domain.CargoAggregate.DomainEventHandler;
public class BookCargoHandler : INotificationHandler<BookCargoCommand>
{
    private readonly ICargoRepository _cargoRepository;
    private readonly IUnitOfWork _unitOfWork;
    public BookCargoHandler(ICargoRepository cargoRepository, IUnitOfWork unitOfWork)
    {
        _cargoRepository = cargoRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(BookCargoCommand notification, CancellationToken cancellationToken)
    {
        var cargo = new Cargo()
            .SetName(notification.Name!)
            .SetWeight(notification.Weight)
            .SetHazMatCode(string.IsNullOrWhiteSpace(notification.HazMatCode) ? default(HazMatCodeEnum?) : Enum.Parse<HazMatCodeEnum>(notification.HazMatCode))
            .SetRouteSpecification(new RouteSpecification(notification.Origin!, notification.Destination!))
            .GenerateTracingId()
            .Book();

        await _cargoRepository.AddAsync(cargo);
        await _unitOfWork.CommitAsync();
    }
}