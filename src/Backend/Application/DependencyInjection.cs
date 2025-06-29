using System.Reflection;
using Backend.Application.Common.Decoupling;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IMediator, Mediator>();

        builder.RegisterHandlers();
    }

    /// <summary>
    /// Automatically registers all Command and Query handlers
    /// </summary>
    /// <param name="builder"></param>
    private static void RegisterHandlers(this IHostApplicationBuilder builder)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes().Where(type => !type.IsAbstract && !type.IsInterface);
        foreach (var type in types)
        {
            var typeInterfaces = type.GetInterfaces();
            foreach (var typeInterface in typeInterfaces)
            {
                List<Type> searchedTypes = [typeof(ICommandHandler<,>), typeof(IQueryHandler<,>)];
                if (typeInterface.IsGenericType && searchedTypes.Contains(typeInterface.GetGenericTypeDefinition()))
                {
                    builder.Services.AddScoped(typeInterface, type);
                }
            }
        }
    }
}