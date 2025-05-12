using HRBackend.Domain.Entities;
using HRBackend.Domain.Enums;

public class Candidate
{
    public int Id { get; set; }
    public DateTime DateUp { get; set; }
    public int UserId { get; set; }// ID HR-пользователя
    public int WorkingGroupId { get; set; }
    public int PersonalInfoId { get; set; }
    public WorkingGroup WorkingGroup { get; set; }
    public PersonalInfo PersonalInfo { get; set; }
    public StatusCandidataEnum StatusCandidat { get; set; }
    public NameWorkScheduleEnum NameWorkSchedule { get; set; }
}

