using Backend.Api.Common.ModelBinding;
using Backend.Api.Data.Helpers;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddApiServices(this WebApplicationBuilder builder)
    {
        builder.AddServiceDefaults();

        builder.Services.AddDbContext<AppDbContext>((sp, options) =>
            options
                .UseNpgsql(builder.Configuration.GetConnectionString("postgresdb"))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(
                    sp.GetRequiredService<AuditColumnInterceptor>()
                ));

        builder.Services.AddSingleton<TimeProvider>(TimeProvider.System);
        builder.Services.AddSingleton<AuditColumnInterceptor>();
        builder.Services.AddTransient<DbInitializer>();

        builder.Services.Configure<RouteOptions>(opt => opt.ConstraintMap.Add("shortguid", typeof(ShortGuidRouteConstraint)));

        builder.Services.AddFastEndpoints().SwaggerDocument(opt => opt.ShortSchemaNames = true);

        return builder;
    }
}
