using AutoMapper;
using HRBackend.Application.DTO;
using HRBackend.Application.Request;
using HRBackend.Domain.Entities;
using MediatR;
using HRBackend.Domain.Enums;
using HRBackend.Domain.Repositories;

namespace HRBackend.Application.Handlers
{
    public class RegisterUserHandler(IUserReposiotry userReposiotry,IMapper mapper) : IRequestHandler<RegisterUserHRRequest, UserDTO>
    {


        public async Task<UserDTO> Handle(RegisterUserHRRequest request, CancellationToken cancellationToken)
        {
            // Проверка, что пользователь с таким логином уже существует
            var existingUser = await userReposiotry.GetByAd(request.Login);


            var workSchedule = await _context.WorkSchedules
                .FirstOrDefaultAsync(ws => ws.Id == request.WorkScheduleId, cancellationToken);

            var workingGroup = await _context.WorkGroups
                .FirstOrDefaultAsync(wg => wg.Id == request.WorkingGroupId, cancellationToken);

            if (existingUser != null)
            {
                throw new Exception("Пользователь с таким логином уже существует.");
            }

            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Middlename = request.Middlename,
                Login = request.Login,
                Password = request.Password, 
                Role = UserRolesEnum.HR,
                WorkSchedule = workSchedule,
                WorkingGroup = workingGroup
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            // Используем AutoMapper для преобразования в DTO
            return _mapper.Map<UserDTO>(user);
        }
    }
}
