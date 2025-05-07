using AutoMapper;
using HRBackend.Application.DTO;
using HRBackend.Application.Request;
using HRBackend.Domain.Entities;
using MediatR;
using HRBackend.Domain.Enums;
using HRBackend.Domain.Repositories;

namespace HRBackend.Application.Handlers
{
    public class RegisterUserHandler(IUserReposiotry userReposiotry,
        IMapper mapper,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<RegisterUserHRRequest, UserDTO>
    {


        public async Task<UserDTO> Handle(RegisterUserHRRequest request, CancellationToken cancellationToken)
        {
            // Проверка, что пользователь с таким логином уже существует
            var existingUser = await userReposiotry.GetByAd(request.Login);


          

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
                //WorkSchedule = workSchedule,
                //WorkingGroup = workingGroup
            };

            //_context.Users.Add(user);через репозиторий

            await unitOfWork.SaveAsync();
            // Используем AutoMapper для преобразования в DTO
            return mapper.Map<UserDTO>(user);
        }
    }
}
