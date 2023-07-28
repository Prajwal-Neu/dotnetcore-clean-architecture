using CleanArchitecture.Application;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Person.Commands;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddApplication().AddInfrastructure();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// Database Connection
var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<PersonDbContext>(opt => opt.UseSqlServer(cs));

// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePerson).Assembly));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
