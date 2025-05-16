using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRBackend.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false);

            var config = builder.Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(config);

        

            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(connectionString,
                builder => { builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName); });

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
