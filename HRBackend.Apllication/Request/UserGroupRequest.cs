using MediatR;

namespace HRBackend.Apllication.Request
{
    public class UserGroupRequest : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
