using HRBackend.Application.Request;
using HRBackend.Domain.Entities;

namespace HRBackend.Application.Interface
{
    public interface IUserService
    {
        Task<string> RegisterUserAsHRAsync(RegisterUserHRRequest request, CancellationToken cancellationToken);
        Task<Users> AuthenticateUserAsync(string login, string password, CancellationToken cancellationToken);
    }
}
