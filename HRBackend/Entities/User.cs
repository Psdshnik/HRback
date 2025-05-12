using HRBackend.Domain.Enums;

namespace HRBackend.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int WorkingGroupId { get; set; }
        public int PersonalInfoId {get; set; }
        public WorkingGroup WorkingGroup { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public NameWorkScheduleEnum NameWorkSchedule { get; set; }
        public UserRolesEnum Role { get; set; }
    }
}