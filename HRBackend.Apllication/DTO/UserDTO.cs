using HRBackend.Domain.Entities;
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
        /*public UserDTO(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Name = user.Name;
            Surname = user.Surname;
            Middlename = user.Middlename;
            Role = user.Role;
        }*/
    }
}
