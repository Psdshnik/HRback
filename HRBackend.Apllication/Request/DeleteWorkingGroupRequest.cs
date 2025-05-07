using MediatR;

namespace HRBackend.Application.Request
{
    public class DeleteWorkingGroupRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
