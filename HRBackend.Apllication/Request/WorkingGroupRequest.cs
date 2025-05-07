using MediatR;
using HRBackend.Application.DTO;

namespace HRBackend.Application.Request
{
    public class WorkingGroupRequest : IRequest<WorkingGroupDTO>
    {
        public string Name { get; set; }
    }
}
