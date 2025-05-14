using HRBackend.Domain.Enums;

namespace HRBackend.Domain.Repositories
{
    public interface IWorkScheduleRepository
    {
        Task<NameWorkScheduleEnum?> GetByIdAsync(int id);
    }
}
