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
    }
}