using HRBackend.Application.DTO;
using HRBackend.Application.Interface;
using HRBackend.Application.Request;
using HRBackend.Domain.Entities;
using HRBackend.Domain.Enums;
using HRBackend.Domain.Repositories;

namespace HRBackend.Application.Services
{
    public class UserService(IUserReposiotry UserRepository,
    IUnitOfWork unitOfWork) : IUserService
    {

        private async Task<bool> IsUserExistAsync(string login, CancellationToken cancellationToken)
        {
            var existingUser = await UserRepository.GetByAd(login); // Используем существующий метод GetByAd
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
            UserRepository.Add(user);

            // Сохраняем изменения
            await unitOfWork.SaveAsync(cancellationToken);

            return $"Пользователь {request.Login} зарегистрирован с ролью HR.";
        }

        public async Task<UserDTO?> AuthenticateUserAsync(string login, string password, CancellationToken cancellationToken)
        {

            // Поиск пользователя в репозитории
            var user = await UserRepository.GetByAdPass(login, password);

            if (user == null)
                return null; // Пользователь не найден или пароль неверный

            // Возвращаем DTO
            return new UserDTO(user)
            {
                Id = user.Id,
                Login = user.Login,
                Role = user.Role,
                // Другие необходимые свойства
            };
        }
    }
}
