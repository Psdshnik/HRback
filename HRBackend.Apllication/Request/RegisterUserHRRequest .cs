using HRBackend.Application.DTO;
using HRBackend.Domain.Enums;
using MediatR;

namespace HRBackend.Application.Request
{
    public class RegisterUserHRRequest : IRequest<UserDTO>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public NameWorkScheduleEnum NameWorkSchedule { get; set; } 
        public int WorkingGroupId { get; set; } 
    }
}
