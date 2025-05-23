using HRBackend.Domain.Enums;

namespace HRBackend.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int WorkingGroupId { get; set; }
        public WorkingGroup WorkingGroup { get; set; }
        public NameWorkScheduleEnum NameWorkSchedule { get; set; }
        public UserRolesEnum Role { get; set; }
        public ICollection<Candidate> Candidates { get; set; }=new List<Candidate>();//все добавленные юзером кандидаты
        public ICollection<Check> Checks { get; set; } =new List<Check>();//все проведенные юзером проверки
    }
}