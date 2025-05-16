using HRBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HRBackend.Persistence.EntityTypeConfigurations;
using HRBackend.Domain.Enums;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using System.Reflection;
using HRBackend.Domain.Entities.Checks;

namespace HRBackend.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<DictCountry> DictCountry { get; set; }
        public DbSet<Candidate> Candidates { get; set; } 
        public DbSet<PersonalInfo> PersonalInfo { get; set; } 
        public DbSet<WorkingGroup> WorkGroups { get; set; } 
        public DbSet<Check> Checks { get; set; } 
        public DbSet<CheckEvent> CheckEvents { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.LogTo(log =>
            {
                Console.WriteLine($"{log}{Environment.NewLine}");
            }, new[] { RelationalEventId.CommandExecuted });
#endif
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}