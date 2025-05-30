
using HRBackend.Application.DTO;
using HRBackend.Domain.Enums;
using MediatR;

namespace HRBackend.Application.Request
{
    public class CandidateUpdateRequest : IRequest<CandidateDTO>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Middlename { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public NameSocailEnum? NameSocail { get; set; }
        public int? CountryId { get; set; }
        public DateTime? BirthDate { get; set; }
        public NameWorkScheduleEnum? WorkSchedule { get; set; }
        public StatusCandidataEnum? StatusCandidataId { get; set; }
    }
}
