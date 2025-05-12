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
        /*public CandidateDTO(Candidate newCandidate)
        {
            Id = newCandidate.Id;
            Name = newCandidate.PersonalInfo.Name;
            Surname = newCandidate.PersonalInfo.Surname;
            Middlename = newCandidate.PersonalInfo.Middlename;
            Email = newCandidate.PersonalInfo.Email;
            Phone = newCandidate.PersonalInfo.Phone;
            SocialMedia = newCandidate.PersonalInfo.NameSocail;  // Пример использования других данных
            Country = request.Country;  // Пример использования данных из запроса, !!! если у тебя что-то в бд не идет, то в запросе оно не нужно и назад оно не нужно
            BirthDate = request.BirthDate;  // Пример использования данных из запроса
            WorkSchedule = newCandidate.WorkSchedule.Name;
            WorkingGroup = newCandidate.WorkingGroup.Name;
            Status = newCandidate.StatusCandidataId.Name;
            // DateUp = newCandidate.DateUp
        }*/
    }
}