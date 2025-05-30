using HRBackend.Application.DTO;
using HRBackend.Domain.Entities;
using HRBackend.Domain.Enums;
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
        public NameSocailEnum NameSocail { get; set; }
        public int CountryId { get; set; }
        public DateTime BirthDate { get; set; }
        public NameWorkScheduleEnum WorkSchedule { get; set; }
        public StatusCandidataEnum StatusCandidataId { get; set; }
    }
}
