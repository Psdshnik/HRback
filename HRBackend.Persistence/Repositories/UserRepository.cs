using HRBackend.Domain.Entities;
using HRBackend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBackend.Persistence.Repositories
{
    public class UserRepository(AppDbContext dbContext) : IUserReposiotry
    {
        public async Task<IEnumerable<User>?> GetAll() => await dbContext.Users.ToListAsync();

        public async Task<User?> GetByAd(string ad)=> await dbContext.Users
            .Include(x => x.NameWorkSchedule)
            .Include(x => x.WorkingGroup)
            .FirstOrDefaultAsync(x => x.Login==ad);

        public async Task<User?> GetById(int id) => await dbContext.Users
            .Include(x=>x.NameWorkSchedule)
            .Include(x=>x.WorkingGroup)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
