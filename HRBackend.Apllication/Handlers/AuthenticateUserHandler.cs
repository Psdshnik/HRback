using MediatR;
using HRBackend.Application.Request;
using HRBackend.Application.DTO;
using HRBackend.Domain.Repositories;

namespace HRBackend.Application.Handlers
{
    public class AuthenticateUserHandler(IUserReposiotry userReposiotry) : IRequestHandler<LoginRequest, UserDTO>
    {
         

        public async Task<UserDTO> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await userReposiotry.GetByAd(request.Login);
            if (user == null)
                throw new Exception("�������� ����� ��� ������.");//���� �������� ����� ��������������� ������(������� ����� AuthException � ���������� �� Exception � ��)

            if(!string.Equals(user.Password,request.Password))
                throw new Exception("�������� ����� ��� ������.");

            // ���������� UserDTO
            return new UserDTO(user);
        }
    }
}
