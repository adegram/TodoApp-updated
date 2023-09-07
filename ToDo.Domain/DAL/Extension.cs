using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Domain.DAL;

public static class Extenstion
{
    public static IServiceCollection AddMSSql(this IServiceCollection services, IConfiguration configuration) // Here we add our database configuration
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}