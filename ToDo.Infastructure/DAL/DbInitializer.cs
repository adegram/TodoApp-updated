using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Infastructure.DAL;

public static class DbInitializer
{
    public static async void InitializeDb(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            var dbContext = services.GetService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }
    }
}