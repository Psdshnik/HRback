using AutoMapper;
using HRBackend.Application.DTO;
using HRBackend.Application.Request;
using HRBackend.Application.Interface;
using HRBackend.Domain.Entities;
using MediatR;
using HRBackend.Application.Services;
using System.Threading;

namespace HRBackend.Application.Handlers
{
    public class WorkingGroupUpdateHandler : IRequestHandler<UpdateWorkingGroupRequest, WorkingGroupDTO>
    {
        private readonly IWorkingGroupService _workingGroupService;
        private readonly IMapper _mapper;

        public WorkingGroupUpdateHandler(IWorkingGroupService workingGroupService, IMapper mapper)
        {
            _workingGroupService = workingGroupService;
            _mapper = mapper;
        }

        public async Task<WorkingGroupDTO> Handle(UpdateWorkingGroupRequest request, CancellationToken cancellationToken)
        {
            var updatedGroup = await _workingGroupService.UpdateWorkingGroupAsync(request, cancellationToken);
            return _mapper.Map<WorkingGroupDTO>(updatedGroup);
        }
    }
}