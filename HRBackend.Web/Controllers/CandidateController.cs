using HRBackend.Application.DTO;
using HRBackend.Application.Interface;
using HRBackend.Application.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[Route("api/[controller]")]
[ApiController]
public class CandidateController : ControllerBase
{
    private readonly ICandidateService _candidateService;

    public CandidateController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    [HttpPost("create-candidate")]
    [Authorize(Roles = "HR")]
    [SwaggerOperation(Summary = "Создание кандидата", Description = "Создает нового кандидата")]
    [SwaggerResponse(200, "Кандидат успешно создан", typeof(CandidateDTO))]
    [SwaggerResponse(401, "Пользователь не имеет прав", typeof(string))]
    [SwaggerResponse(400, "Ошибка при создании кандидата", typeof(string))]
    public async Task<IActionResult> CreateCandidate([FromQuery] CandidateDTO candidate, CancellationToken cancellationToken)
    {
        try
        {
            CandidateCreateRequest request = null;

            var result = await _candidateService.CreateCandidateAsync(request, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ошибка: {ex.Message}");
        }
    }

    [HttpPut("update-candidate")]
    [Authorize(Roles = "HR")]
    [SwaggerOperation(Summary = "Обновление кандидата", Description = "Обновляет данные кандидата")]
    [SwaggerResponse(200, "Кандидат успешно обновлен", typeof(CandidateDTO))]
    [SwaggerResponse(400, "Ошибка при обновлении кандидата", typeof(string))]
    public async Task<IActionResult> UpdateCandidate([FromBody] CandidateUpdateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _candidateService.UpdateCandidateAsync(request, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Ошибка: {ex.Message}");
        }
    }
}
