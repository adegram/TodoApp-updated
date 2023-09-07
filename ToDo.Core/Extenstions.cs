using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Core.Services;

namespace ToDo.Core;

public static class Extenstions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration) // Add our services to configuration
    {
        services.AddScoped<ITodoService, TodoService>();
        return services;
    }
}