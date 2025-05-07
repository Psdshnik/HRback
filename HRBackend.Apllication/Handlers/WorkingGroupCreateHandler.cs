using AutoMapper;
using HRBackend.Application.DTO;
using HRBackend.Application.Request;
using HRBackend.Application.Interface;
using HRBackend.Domain.Entities;
using MediatR;

namespace HRBackend.Application.Handlers
{
    public class WorkingGroupCreateHandler : IRequestHandler<WorkingGroupRequest, WorkingGroupDTO>
    {
        private readonly IWorkingGroupService _workingGroupService;
        private readonly IMapper _mapper;

        public WorkingGroupCreateHandler(IWorkingGroupService workingGroupService, IMapper mapper)
        {
            _workingGroupService = workingGroupService;
            _mapper = mapper;
        }

        public async Task<WorkingGroupDTO> Handle(WorkingGroupRequest request, CancellationToken cancellationToken)
        {
            var createdGroup = await _workingGroupService.CreateWorkingGroupAsync(request, cancellationToken);

            return _mapper.Map<WorkingGroupDTO>(createdGroup);
        }
    }
}
