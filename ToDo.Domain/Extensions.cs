using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.DAL;
using ToDo.Domain.IRepository;

namespace ToDo.Domain;

public static class Extensions
{
    public static IServiceCollection AddInfastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITodoRepository, TodoRepository>();
        services.AddMSSql(configuration);
        return services;
    }
}