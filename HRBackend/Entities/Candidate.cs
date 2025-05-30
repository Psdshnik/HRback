using HRBackend.Domain.Entities;
using HRBackend.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

public class Candidate
{
    public int Id { get; set; }
    public DateTime DateUp { get; set; }
    public StatusCandidataEnum Status { get; set; }
    public NameWorkScheduleEnum WorkSchedule { get; set; }
    public int UserId { get; set; }// ID HR-пользователя
    public User User { get; set; } = null!;
    public int PersonalInfoId { get; set; }
    public PersonalInfo PersonalInfo { get; set; } = null!;


    public override bool Equals(object? obj)
    {
        var item = obj as Candidate;

        if (item == null)
        {
            return false;
        }

        return Id.Equals(item.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

