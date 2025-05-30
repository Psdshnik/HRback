using HRBackend.Domain.Repositories;

namespace HRBackend.Persistence.Repositories
{
    public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
    {
        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}