using Backend.Application.Common.Interfaces;
using Backend.Application.Dto;
using Backend.Application.UseCases.Challenges;

using Microsoft.AspNetCore.Mvc;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructureServices();
builder.AddApplicationServices();
builder.AddApiServices();

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

app.MapPost("/challenges", async (CreateChallengeCommand command, [FromServices] IMediator mediator) =>
    await mediator.SendCommandAsync<CreateChallengeCommand, ChallengeDto>(command));

app.Run();
