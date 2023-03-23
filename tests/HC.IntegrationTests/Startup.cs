using System;
using System.Reflection;
using HC.Domain;
using HC.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;

namespace HC.IntegrationTests;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddApplicationPart(Assembly.Load("HC.WebApi"));
        services.AddDbContext<BaseDbContext, TrafficDbContext>(options =>
        {
            options.UseInMemoryDatabase($"MemoryDb:{Guid.NewGuid()}");
        });
        services.AddRepository();
        services.AddApplication();

        services.AddMediatR(
            Assembly.Load("HC.WebApi"),
            Assembly.Load("HC.Application"),
            Assembly.Load("HC.Domain"),
            Assembly.Load("HC.Repository")
        );
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}