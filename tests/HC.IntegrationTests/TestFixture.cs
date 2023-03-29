using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace HC.IntegrationTests;

public class TestFixture<TStartup> : IDisposable where TStartup : class
{
    private readonly TestServer _testServer;
    public TestFixture()
    {
        var builder = new WebHostBuilder().UseStartup<TStartup>();
        _testServer = new TestServer(builder);
        HttpClient = _testServer.CreateClient();
    }

    public HttpClient HttpClient { get; }
    public TestServer TestServer { get { return _testServer; } }

    public void Dispose()
    {
        HttpClient.Dispose();
        TestServer.Dispose();
    }
}