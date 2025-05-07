using MediatR;
using HRBackend.Application.DTO;


public record GetAllUsersQuery() : IRequest<List<UserDTO>>;