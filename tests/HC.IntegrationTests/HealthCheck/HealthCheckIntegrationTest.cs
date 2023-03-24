using System.Threading.Tasks;
using Xunit;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;

namespace HC.IntegrationTests.HealthCheck;

[Collection("HealthCheck")]
public class HealthCheckIntegrationTest
{
    [Fact]
    public async Task HealthCheck_ShouldBe_Return_Healthy()
    {
        //Arrange
        var hostBuilder = new WebHostBuilder()
        .ConfigureServices(services =>
        {
            services.AddRouting();
            services.AddHealthChecks();
        })
        .Configure(app =>
        {
            app.UseRouting();
            app.UseEndpoints(s => s.MapHealthChecks("/health", new HealthCheckOptions()
            {
                AllowCachingResponses = false,
                ResponseWriter = (context, report)
                => context.Response.WriteAsync(JsonConvert.SerializeObject(new { Status = report.Status.ToString() })),
                ResultStatusCodes ={
                        [HealthStatus.Healthy]=StatusCodes.Status200OK,
                        [HealthStatus.Degraded]=StatusCodes.Status200OK,
                        [HealthStatus.Unhealthy]=StatusCodes.Status503ServiceUnavailable
                    }
            }));
        });

        using (var testServer = new TestServer(hostBuilder))
        {
            //Act
            var response = await testServer.CreateRequest("health").SendAsync("GET");

            //Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.Equal(result, JsonConvert.SerializeObject(new { Status = "Healthy" }));
        }
    }
}