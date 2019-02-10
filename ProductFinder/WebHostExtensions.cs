using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProductFinder.Contexts;

namespace ProductFinder
{
    public static class WebHostExtensions
    {
        public static IWebHost SeedData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ProductDbContext>();
                context.SeedDatabase();
            }
            return host;
        }
    }
}