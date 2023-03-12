using HC.Domain;
using HC.WebApi.Extensions;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddMediatR(
    Assembly.Load("HC.WebApi"),
    Assembly.Load("HC.Application"),
    Assembly.Load("HC.Domain"),
    Assembly.Load("HC.Repository")
    );
builder.Services.AddDbContext<BaseDbContext, TrafficDbContext>();
builder.Services.AddRepository();
builder.Services.AddAutoMapper(
    Assembly.Load("HC.WebApi"),
    Assembly.Load("HC.Application"),
    Assembly.Load("HC.Domain")
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
