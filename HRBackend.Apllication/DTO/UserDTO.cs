using HRBackend.Domain.Enums;

namespace HRBackend.Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Login { get; set; }
        public UserRolesEnum Role { get; set; }
    }
}
