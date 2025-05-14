/*using HRBackend.Application.Interface;
using HRBackend.Application.Request;
using HRBackend.Domain.Entities;
using HRBackend.Domain.Enums;

namespace HRBackend.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAppDbContext _context;

        public UserService(IAppDbContext context)
        {
            _context = context;
        }

        private async Task<bool> IsUserExistAsync(string login, CancellationToken cancellationToken)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Login == login, cancellationToken);

            return existingUser != null;
        }



        public async Task<string> RegisterUserAsHRAsync(RegisterUserHRRequest request, CancellationToken cancellationToken)
        {

            if (await IsUserExistAsync(request.Login, cancellationToken))
            {
                return "Пользователь с таким логином уже существует.";
            }

            // Получение WorkSchedule и WorkingGroup по их ID
            var workSchedule = await _context.WorkSchedules
                .FirstOrDefaultAsync(ws => ws.Id == request.WorkScheduleId, cancellationToken);

            var workingGroup = await _context.WorkGroups
                .FirstOrDefaultAsync(wg => wg.Id == request.WorkingGroupId, cancellationToken);

            // Проверка, что WorkSchedule и WorkingGroup существуют
            if (workSchedule == null || workingGroup == null)
            {
                return "Неверные ID для рабочего расписания или рабочей группы.";
            }

            var user = new User
            {
                Surname = request.Surname,
                Name = request.Name,
                Middlename = request.Middlename,
                Login = request.Login,
                Password = request.Password,
                Role = UserRolesEnum.HR,
                WorkSchedule = workSchedule,
                WorkingGroup = workingGroup
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return $"Пользователь {request.Surname} {request.Name} зарегистрирован с ролью HR.";
        }



        public async Task<User> AuthenticateUserAsync(string login, string password, CancellationToken cancellationToken)
        {
            // Проверка существования пользователя с таким логином и паролем
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Login == login && u.Password == password, cancellationToken);

            return user; // Если пользователь найден, возвращаем его, иначе вернем null
        }
    }
}
*/