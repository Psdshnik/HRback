using MediatR;
using HRBackend.Application.Request;
using HRBackend.Application.DTO;
using HRBackend.Application.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using HRBackend.Apllication.Interface;

namespace HRBackend.Application.Handlers
{
    public class AuthenticateUserHandler : IRequestHandler<LoginRequest, UserDTO>
    {
        private readonly IAppDbContext _context;

        public AuthenticateUserHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Login == request.Login && u.Password == request.Password, cancellationToken);

            if (user == null)
            {
                throw new Exception("Неверный логин или пароль.");
            }

            // Возвращаем UserDTO
            return new UserDTO
            {
                Id = user.Id,
                Login = user.Login,
                Name = user.Name,
                Surname = user.Surname,
                Middlename = user.Middlename,
                Role = user.Role
            };
        }
    }
}
