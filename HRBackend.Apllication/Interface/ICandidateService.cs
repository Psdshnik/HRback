using HRBackend.Application.DTO;
using HRBackend.Application.Request;

namespace HRBackend.Application.Interface
{
    public interface ICandidateService
    {
        Task<CandidateDTO> CreateCandidateAsync(CandidateCreateRequest request, CancellationToken cancellationToken);
        Task<CandidateDTO> UpdateCandidateAsync(CandidateUpdateRequest request, CancellationToken cancellationToken);
    }
}
