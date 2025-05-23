using HRBackend.Application.DTO;
using HRBackend.Application.Interface;
using HRBackend.Application.Request;
using HRBackend.Domain.Entities;
using HRBackend.Domain.Enums;
using HRBackend.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HRBackend.Application.Services
{
    public class UserService(IUserReposiotry userReposiotry,
    IUnitOfWork unitOfWork) : IUserService
    {
        


        /*private async Task<bool> IsUserExistAsync(string login, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByAd(login); // Используем существующий метод GetByAd
            return existingUser != null;
        }

        public async Task<string> RegisterUserAsHRAsync(RegisterUserHRRequest request, CancellationToken cancellationToken)
        {
            if (await IsUserExistAsync(request.Login, cancellationToken))
                return "Пользователь с таким логином уже существует.";

            var user = new User
            {
                Login = request.Login,
                Password = request.Password,
                Role = UserRolesEnum.HR,
                NameWorkSchedule = request.NameWorkSchedule, // Enum передаётся напрямую из запроса
                WorkingGroupId = request.WorkingGroupId
            };

            // Добавляем пользователя
            _userRepository.Add(user);

            // Сохраняем изменения
            await _unitOfWork.SaveAsync(cancellationToken);

            return $"Пользователь {request.Login} зарегистрирован с ролью HR.";
        }*/

        public async Task<UserDTO?> AuthenticateUserAsync(string login, string password, CancellationToken cancellationToken)
        {
            var user = await userReposiotry.GetByAdPass(login, password);
            if (user == null)
                return null;

            return new UserDTO(user);
        }


    }
}
