using HRBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HRBackend.Persistence.EntityTypeConfigurations;

namespace HRBackend.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<Employees> Employees { get; set; } 
        public DbSet<Candidate> Candidates { get; set; } 
        public DbSet<PersonalInfo> PersonalInfo { get; set; } 
        public DbSet<TypeSocail> TypeSocail { get; set; } 
        public DbSet<WorkingGroup> WorkGroups { get; set; } 
        public DbSet<WorkSchedule> WorkSchedules { get; set; } 
        public DbSet<Check> Checks { get; set; } 
        public DbSet<DictStatusCandidata> DictStatusCandidata { get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidatesConfiguration());
            modelBuilder.ApplyConfiguration(new CheckConfiguration());
            modelBuilder.ApplyConfiguration(new DictStatusCandidataConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeesConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalInfoConfiguration());
            modelBuilder.ApplyConfiguration(new TypeSocailConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new WorkingGroupConfiguration());
            modelBuilder.ApplyConfiguration(new WorkScheduleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}