using HRBackend.Apllication.Interface;
using HRBackend.Application.Interface;
using HRBackend.Application.Request;
using HRBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRBackend.Application.Services
{
    public class WorkingGroupService : IWorkingGroupService
    {
        private readonly IAppDbContext _context;

        public WorkingGroupService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<WorkingGroup> CreateWorkingGroupAsync(WorkingGroupRequest request, CancellationToken cancellationToken)
        {
            var existingGroup = await _context.WorkGroups
                .FirstOrDefaultAsync(wg => wg.Name == request.Name, cancellationToken);

            if (existingGroup != null)
            {
                throw new Exception("Рабочая группа с таким именем уже существует.");
            }

            var newGroup = new WorkingGroup
            {
                Name = request.Name  // id генерируется автоматически
            };

            _context.WorkGroups.Add(newGroup);
            await _context.SaveChangesAsync(cancellationToken);

            return newGroup;
        }

        // Обновление рабочей группы
        public async Task<WorkingGroup> UpdateWorkingGroupAsync(UpdateWorkingGroupRequest request, CancellationToken cancellationToken)
        {
            var workingGroup = await _context.WorkGroups
                .FirstOrDefaultAsync(wg => wg.Id == request.Id, cancellationToken);

            if (workingGroup == null)
            {
                throw new Exception("Рабочая группа не найдена.");
            }

            workingGroup.Name = request.Name;

            _context.WorkGroups.Update(workingGroup);
            await _context.SaveChangesAsync(cancellationToken);

            return workingGroup;
        }

        // Удаление рабочей группы
        public async Task<bool> DeleteWorkingGroupAsync(DeleteWorkingGroupRequest request, CancellationToken cancellationToken)
        {
            var workingGroup = await _context.WorkGroups
                .FirstOrDefaultAsync(wg => wg.Id == request.Id, cancellationToken);

            if (workingGroup == null)
            {
                throw new Exception("Рабочая группа не найдена.");
            }

            _context.WorkGroups.Remove(workingGroup);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
