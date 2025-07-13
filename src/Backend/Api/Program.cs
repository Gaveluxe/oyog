using Backend.Api.Data.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.AddApiServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<DbInitializer>().Run();
}

app.UseFastEndpoints();
app.MapDefaultEndpoints();

app.Run();
