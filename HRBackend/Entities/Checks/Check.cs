using HRBackend.Domain.Entities;
using HRBackend.Domain.Entities.Checks;

public class Check
{
    public int Id { get; set; }
    public DateTime DateCheck { get; set; }
    public int CreatedId { get; set; } // HR который делает проверку
    public string Event { get; set; }
    public int UserId { get; set; } // Пользователь которого проверяют 
    public User User { get; set; } = null!;
    public ICollection<CheckEvent> CheckEvent { get; set; }=new List<CheckEvent>();
}
