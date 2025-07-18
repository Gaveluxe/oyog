using Backend.Api.Data.Helpers;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.AddApiServices();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    await scope.ServiceProvider.GetRequiredService<DbInitializer>().RunAsync();
}

app.UseFastEndpoints();
app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi(cfg => cfg.Path = "/openapi/{documentName}.json");
    app.MapScalarApiReference();
}

await app.RunAsync();
