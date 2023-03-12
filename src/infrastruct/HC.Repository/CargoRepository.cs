using HC.Domain;
using HC.Domain.CargoAggregate.Entity;
using HC.Domain.CargoAggregate.Repository;

namespace HC.Repository
{
    public class CargoRepository : ICargoRepository
    {
        private readonly BaseDbContext _context;
        public CargoRepository(BaseDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Cargo entity)
        {
           await _context.AddAsync(entity);
        }
    }
}