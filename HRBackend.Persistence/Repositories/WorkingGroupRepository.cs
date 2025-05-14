using HRBackend.Domain.Entities;
using HRBackend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HRBackend.Persistence.Repositories
{
    public class WorkScheduleRepository(AppDbContext dbContext) : IWorkScheduleRepository
    {

        public async Task<WorkSchedule?> GetByIdAsync(int id)
        {
            return await dbContext.WorkSchedules
                .FirstOrDefaultAsync(ws => ws.Id == id);
        }
    }
}
