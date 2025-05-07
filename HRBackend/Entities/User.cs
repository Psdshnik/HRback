using HRBackend.Domain.Enums;

namespace HRBackend.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int WorkingGroupId { get; set; }
       
        public WorkingGroup WorkingGroup { get; set; }
        public UserRolesEnum Role { get; set; }
    }
}