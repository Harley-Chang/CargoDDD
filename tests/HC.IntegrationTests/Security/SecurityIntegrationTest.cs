using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace HC.IntegrationTests.Security;

public class SecurityIntegrationTest
{
    private readonly IWebHostBuilder _builder;
    public SecurityIntegrationTest()
    {
        var headerPolicyCollection = new HeaderPolicyCollection().AddDefaultSecurityHeaders();

        _builder = new WebHostBuilder()
          .ConfigureServices(services =>
          {
              services.AddControllers();
          })
          .Configure(app =>
          {
              app.UseSecurityHeaders(headerPolicyCollection);
              app.UseRouting();
              app.Map("/security-header", builder =>
              {
                  builder.Run(async (context) =>
                  {
                      await context.Response.WriteAsync("Test response");
                  });
              });
          })
          .UseKestrel(options =>
          {
              options.AddServerHeader = false;
          });
    }

    [Fact]
    public async Task SecurityHeader_ShouldBe_Remove_ServerHeader()
    {
        //Arrange
        using (var testServer = new TestServer(_builder))
        {
            //Act
            var response = await testServer.CreateRequest("security-header").SendAsync("GET");

            //Assert
            response.EnsureSuccessStatusCode();
            var content =await response.Content.ReadAsStringAsync();
            Assert.Equal(content,"Test response");
            Assert.False(response.Headers.Contains("Server"),"Response headers should not contain server header.");
        }
    }
}