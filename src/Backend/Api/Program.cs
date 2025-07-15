using Backend.Api.Data.Helpers;

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

await app.RunAsync();
