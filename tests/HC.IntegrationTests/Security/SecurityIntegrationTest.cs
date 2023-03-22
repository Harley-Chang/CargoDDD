using System.Threading.Tasks;
using Xunit;
using System.Net;

namespace HC.IntegrationTests.Security;

[Collection("Health")]
public class SecurityIntegrationTest : IClassFixture<TestFixture<Startup>>
{
    private readonly TestFixture<Startup> _fixture;
    public SecurityIntegrationTest(TestFixture<Startup> fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task HealthCheck_ShouldBe_Return_Healthy()
    {
        //Arrange
        //Act
        var response = await _fixture.TestServer.CreateRequest("health").SendAsync("GET");

        //Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        Assert.Equal(result, "healthy");
    }
}