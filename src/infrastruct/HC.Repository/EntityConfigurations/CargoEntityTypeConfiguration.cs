using HC.Domain.CargoAggregate.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HC.Repository.EntityConfigurations;

public class CargoEntityTypeConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.TracingId)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(s => s.Name).HasMaxLength(200);
        //从属实体类型属性
        builder.OwnsOne(s => s.RouteSpecification, a =>
        {
            a.Property(b => b.Origin).HasMaxLength(500);
            a.Property(b => b.Destination).HasMaxLength(500);
        });

        //将枚举转为字符串，增加可视化、可维护性
        builder.Property(s => s.HazMatCode).HasMaxLength(50)
            .IsUnicode(false).HasConversion<string>();
    }
}