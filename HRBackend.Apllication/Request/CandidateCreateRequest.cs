using HRBackend.Application.DTO;
using MediatR;

namespace HRBackend.Application.Request
{
    public class CandidateCreateRequest : IRequest<CandidateDTO>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SocialMedia { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public int WorkScheduleId { get; set; }
        public int WorkingGroupId { get; set; }
        public int StatusCandidataId { get; set; }
        public int PersonalInfoId { get; set; }
        public int UserId { get; set; }
    }
}
