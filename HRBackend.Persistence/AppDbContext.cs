using HRBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HRBackend.Persistence.EntityTypeConfigurations;
using HRBackend.Domain.Enums;

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

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Регистрация enum-типов PostgreSQL
            modelBuilder.HasPostgresEnum<NameSocailEnum>();
            modelBuilder.HasPostgresEnum<NameWorkScheduleEnum>();
            modelBuilder.HasPostgresEnum<StatusCandidataEnum>();
            modelBuilder.HasPostgresEnum<TypeEventEnum>();
            modelBuilder.HasPostgresEnum<UserRolesEnum>();

            modelBuilder.ApplyConfiguration(new CandidatesConfiguration());
            modelBuilder.ApplyConfiguration(new CheckConfiguration());
            modelBuilder.ApplyConfiguration(new DictCountryConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalInfoConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new WorkingGroupConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}