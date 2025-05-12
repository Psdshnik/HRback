using HRBackend.Domain.Entities;

public class Check
{
    public int Id { get; set; }
    public DateTime DateCheck { get; set; }
    public int CreatedId { get; set; } // HR который делает проверку
    public string Event { get; set; }
    public int UserId { get; set; } // Пользователь которого проверяют 
    public User User { get; set; }
}
