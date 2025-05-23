using HRBackend.Application.DTO;
using HRBackend.Application.Request;
using HRBackend.Domain.Entities;

namespace HRBackend.Application.Interface
{
    public interface IUserService
    {
        //Task<string> RegisterUserAsHRAsync(RegisterUserHRRequest request, CancellationToken cancellationToken);
        //Task<User> AuthenticateUserAsync(string login, string password, CancellationToken cancellationToken);
        Task<UserDTO?> AuthenticateUserAsync(string login, string password, CancellationToken cancellationToken);
    }
}
