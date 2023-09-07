using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Infastructure.DAL.Repository;

namespace ToDo.Infastructure.DAL;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMSSql(configuration);
        services.AddScoped<ITodoRepository, TodoRepository>();
        return services;
    }
    
    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.Services.InitializeDb();
        return app;
    }
}