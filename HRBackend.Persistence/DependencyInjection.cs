// HRBackend.Persistence/DependencyInjection.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRBackend.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
               options.UseNpgsql(connectionString,
                builder =>
                {
                    builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                }));

            return services;
        }
    }
}
