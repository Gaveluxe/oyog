using Backend.Api.Data.Helpers;
using FastEndpoints.ClientGen.Kiota;
using Kiota.Builder;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.AddApiServices();

var app = builder.Build();

app.UseFastEndpoints();
await app.GenerateApiClientsAndExitAsync(
    c =>
    {
        c.SwaggerDocumentName = "v1";
        c.Language = GenerationLanguage.TypeScript;
        c.OutputPath = Path.Combine(app.Environment.ContentRootPath, "../../Frontend/src/clients/apiClients");
        c.ClientNamespaceName = "Frontend";
        c.ClientClassName = "ApiClient";
    });

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi(cfg => cfg.Path = "/openapi/{documentName}.json");
    app.MapScalarApiReference();

    using var scope = app.Services.CreateScope();
    await scope.ServiceProvider.GetRequiredService<DbInitializer>().RunAsync();
}

await app.RunAsync();
