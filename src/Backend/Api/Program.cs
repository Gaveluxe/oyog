using Backend.Api.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructureServices();
builder.AddApplicationServices();
builder.AddApiServices();
builder.AddServiceDefaults();

var app = builder.Build();

// Create the database if needed
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<Backend.Infrastructure.Data.ApplicationDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapChallenges();

app.Run();
