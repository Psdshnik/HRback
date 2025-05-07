using HRBackend.Application.DTO;
using MediatR;

namespace HRBackend.Application.Request
{
    public class LoginRequest : IRequest<UserDTO>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}