using MediatR;
using HRBackend.Application.DTO;
using HRBackend.Domain.Repositories;

public class GetAllUsersQueryHandler(IUserReposiotry userRepository) : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDTO>?>
{
    public async Task<IEnumerable<UserDTO>?> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return (await userRepository.GetAll())?
            .Select(u => new UserDTO(u));
    }
}
