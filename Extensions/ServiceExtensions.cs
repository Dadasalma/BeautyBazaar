using BeautyBazaar.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautyBazaar.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}