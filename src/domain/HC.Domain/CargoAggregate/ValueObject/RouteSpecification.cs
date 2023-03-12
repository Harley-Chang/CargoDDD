namespace HC.Domain.CargoAggregate.ValueObject
{
    public class RouteSpecification
    {
        public RouteSpecification(string origin, string destination)
        {
            Origin = origin;
            Destination = destination;
        }

        public string? Origin { get; private set; }
        public string? Destination { get; private set; }

        public void SetOrigin(string origin)
        {
            Origin = origin;
        }

        public void SetDestination(string destination)
        {
            Destination = destination;
        }
    }
}
