using HRBackend.Application.Request;
using HRBackend.Application.Interface;
using MediatR;

namespace HRBackend.Application.Handlers
{
    public class WorkingGroupDeleteHandler : IRequestHandler<DeleteWorkingGroupRequest, bool>
    {
        private readonly IWorkingGroupService _workingGroupService;

        public WorkingGroupDeleteHandler(IWorkingGroupService workingGroupService)
        {
            _workingGroupService = workingGroupService;
        }

        public async Task<bool> Handle(DeleteWorkingGroupRequest request, CancellationToken cancellationToken)
        {
            return await _workingGroupService.DeleteWorkingGroupAsync(request, cancellationToken);
        }
    }
}
