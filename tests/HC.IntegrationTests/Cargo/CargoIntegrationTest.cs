using Xunit;
using System.Net.Http;
using HC.Domain.CargoAggregate.Command;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace HC.IntegrationTests.Cargo;

[Collection("Cargo")]
public class CargoIntegrationTest : IClassFixture<TestFixture<Startup>>
{
    private readonly TestFixture<Startup> _fixture;
    public CargoIntegrationTest(TestFixture<Startup> fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Cargo_Added_ShouldBe_Finded()
    {
        //Arrange
        var cargoName = "书籍";
        var cargoWeight = 50;
        var origin = "北京";
        var destination = "杭州";
        var command = new BookCargoCommand(cargoName, cargoWeight, null, origin, destination);

        //Act
        var response = await _fixture.TestServer
                        .CreateRequest("api/cargo")
                        .And(request =>
                        {
                            request.Content = new StringContent(JsonConvert.SerializeObject(command),new System.Net.Http.Headers.MediaTypeHeaderValue("Application/Json"));
                        })
                        .SendAsync("POST");

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}