using HC.Domain.CargoAggregate.DomainEvent;
using HC.Domain.CargoAggregate.ValueObject;

namespace HC.Domain.CargoAggregate.Entity
{
    public class Cargo : BaseEntity, IAggregateRoot, IDomainEvents
    {
        public string TracingId { get; private set; }
        public string? Name { get; private set; }
        public long Weight { get; private set; }
        public HazMatCodeEnum? HazMatCode { get; private set; }
        public RouteSpecification RouteSpecification { get; private set; }

        public Cargo GenerateTracingId()
        {
            TracingId = $"{DateTime.UtcNow:yyyyMMddHHmmfff}_{new Random().Next(1000, 9000)}";
            return this;
        }

        public Cargo SetWeight(long weight)
        {
            Weight = weight; 
            return this;
        }

        public Cargo SetName(string name)
        {
            Name = name;
            return this;
        }

        public Cargo SetHazMatCode(HazMatCodeEnum? hazMatCode)
        {
            HazMatCode = hazMatCode;
            return this;
        }

        public Cargo SetRouteSpecification(RouteSpecification routeSpecification)
        {
            RouteSpecification = routeSpecification;
            return this;
        }

        public Cargo Book()
        {
            AddDomainEvent(new CargoBookedEvent(TracingId));
            return this;
        }
    }
}
