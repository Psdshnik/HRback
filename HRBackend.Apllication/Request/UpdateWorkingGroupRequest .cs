using HRBackend.Application.DTO;
using MediatR;

namespace HRBackend.Application.Request
{
    public class UpdateWorkingGroupRequest : IRequest<WorkingGroupDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}