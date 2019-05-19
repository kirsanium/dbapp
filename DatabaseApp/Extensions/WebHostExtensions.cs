using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseApp.Extensions
{
    public static class WebHostExtensions
    {
        public static IWebHost WithMigratedDatabase(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
                var seeder = scope.ServiceProvider.GetService<IDataSeeder>();
                
                dbContext.Database.Migrate();
                seeder.Seed(dbContext);
            }
            return host;
        }
    }
}