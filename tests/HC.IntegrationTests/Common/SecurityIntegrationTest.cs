using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Xunit;
using System;

namespace HC.IntegrationTests.Common;

[Collection("Security")]
public class SecurityIntegrationTest : IDisposable
{
    private readonly TestServer _testServer;
    public SecurityIntegrationTest()
    {
        var headerPolicyCollection = new HeaderPolicyCollection().AddDefaultSecurityHeaders();

        var builder = new WebHostBuilder()
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

        _testServer = new TestServer(builder);
    }

    [Fact]
    public async Task SecurityHeader_ShouldBe_Remove_ServerHeader()
    {
        //Arrange
        //Act
        var response = await _testServer.CreateRequest("security-header").SendAsync("GET");

        //Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal(content, "Test response");
        Assert.False(response.Headers.Contains("Server"), "Response headers should not contain server header.");
    }

    public void Dispose()
    {
        _testServer.Dispose();
    }
}