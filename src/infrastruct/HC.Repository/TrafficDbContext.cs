using HC.Domain;
using HC.Domain.CargoAggregate.Entity;
using HC.Repository.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class TrafficDbContext : BaseDbContext
{
    public TrafficDbContext(DbContextOptions options, IMediator mediator) : base(options, mediator)
    {
    }

    public DbSet<Cargo>? Cargos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CargoEntityTypeConfiguration());
    }
}