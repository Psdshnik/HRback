using MediatR;
using Microsoft.EntityFrameworkCore;
using HRBackend.Apllication.Interface;
using HRBackend.Application.DTO;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
{
    private readonly IAppDbContext _context;

    public GetAllUsersQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users
            .Select(u => new UserDTO { Id = u.Id, Login = u.Login })
            .ToListAsync(cancellationToken);
    }
}
