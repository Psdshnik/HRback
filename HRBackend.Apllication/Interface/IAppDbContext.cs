using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HRBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRBackend.Apllication.Interface
{
    public interface IAppDbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Employees> Employees { get; set; } 
        public DbSet<Candidates> Candidates { get; set; } 
        public DbSet<PersonalInfo> PersonalInfo { get; set; } 
        public DbSet<TypeSocail> TypeSocail { get; set; } 
        public DbSet<WorkingGroup> WorkGroups { get; set; } 
        public DbSet<WorkSchedule> WorkSchedules { get; set; } 
        public DbSet<Check> Checks { get; set; } 
        public DbSet<DictStatusCandidata> DictStatusCandidata { get; set; } 
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
