using HRBackend.Domain.Entities;

namespace HRBackend.Application.DTO
{
    public class CandidateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SocialMedia { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public string WorkSchedule { get; set; }
        public string WorkingGroup { get; set; }
        public string Status { get; set; }

        // Конструктор для маппинга данных из сущности Candidate
        public CandidateDTO(Candidate newCandidate)
        {
            Id = newCandidate.Id;
            Name = newCandidate.PersonalInfo?.Name ?? string.Empty;  // Проверяем на null
            Surname = newCandidate.PersonalInfo?.Surname ?? string.Empty;  // Проверяем на null
            Middlename = newCandidate.PersonalInfo?.Middlename ?? string.Empty;  // Проверяем на null
            Email = newCandidate.PersonalInfo?.Email ?? string.Empty;  // Проверяем на null
            Phone = newCandidate.PersonalInfo?.Phone ?? string.Empty;  // Проверяем на null
            SocialMedia = newCandidate.PersonalInfo?.NameSocail.ToString() ?? string.Empty;  // Проверяем на null
            Country = newCandidate.PersonalInfo?.Country?.Name ?? string.Empty;  // Проверяем на null, предполагается, что PersonalInfo имеет связь с DictCountry
            BirthDate = newCandidate.PersonalInfo?.DateAdd ?? DateTime.MinValue;  // Используем DateAdd или другое поле, если BirthDate не хранится в PersonalInfo

            WorkSchedule = newCandidate.NameWorkSchedule.ToString();  // Преобразуем в строку, так как это enum
            WorkingGroup = newCandidate.WorkingGroup?.Name ?? string.Empty;  // Проверяем на null
            Status = newCandidate.StatusCandidat.ToString();  // Преобразуем в строку, так как это enum
        }
    }
}