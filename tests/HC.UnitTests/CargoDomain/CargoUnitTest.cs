using System;
using System.Threading.Tasks;
using HC.Domain.CargoAggregate.Entity;
using HC.Domain.CargoAggregate.ValueObject;
using Xunit;

namespace HC.UnitTests.CargoDomain;

[Collection("Cargo")]
public class CargoUnitTest
{
    [Fact]
    public async Task Cargo_SetProperties_ShouldBe_Whrite()
    {
        //Arrange
        var cargoName = "书籍";
        var cargoWeight = 50;
        var hazMatCode = default(HazMatCodeEnum?);
        var origin = "北京";
        var destination = "杭州";

        //Act
        var cargo = new Cargo()
            .SetName(cargoName)
            .SetWeight(cargoWeight)
            .SetHazMatCode(hazMatCode)
            .SetRouteSpecification(new RouteSpecification(origin, destination))
            .GenerateTracingId();

        //Assert
        Assert.NotNull(cargo);
        Assert.NotNull(cargo.RouteSpecification);
        Assert.Equal(cargo.Name, cargoName);
        Assert.Equal(cargo.Weight, cargoWeight);
        Assert.Equal(cargo.HazMatCode, hazMatCode);
        Assert.Equal(cargo.RouteSpecification.Origin, origin);
        Assert.Equal(cargo.RouteSpecification.Destination, destination);
        Assert.StartsWith($"{DateTime.UtcNow:yyyy}", cargo.TracingId);
        await Task.CompletedTask;
    }
}