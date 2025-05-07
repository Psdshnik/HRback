using HRBackend.Application.DTO;
using MediatR;

namespace HRBackend.Application.Request
{
    public class RegisterUserHRRequest : IRequest<UserDTO>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int WorkScheduleId { get; set; } 
        public int WorkingGroupId { get; set; } 
    }
}
