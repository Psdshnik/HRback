using HRBackend.Application.DTO;
using HRBackend.Application.Request;
using HRBackend.Application.Interface;
using MediatR;

namespace HRBackend.Application.Handlers
{
    public class CandidateCreateHandler : IRequestHandler<CandidateCreateRequest, CandidateDTO>
    {
        private readonly ICandidateService _candidateService;

        public CandidateCreateHandler(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        public async Task<CandidateDTO> Handle(CandidateCreateRequest request, CancellationToken cancellationToken)
        {
            return await _candidateService.CreateCandidateAsync(request, cancellationToken);
        }
    }
}
