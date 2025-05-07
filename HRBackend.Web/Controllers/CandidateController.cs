using HRBackend.Application.Request;
using HRBackend.Application.DTO;
using HRBackend.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using HRBackend.Application.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace HRBackend.Web.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    //[Authorize(Roles = "HR")]
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
        //[SwaggerResponse(200, "Кандидат успешно создан", typeof(CandidateDTO))]
        [SwaggerResponse(401, "Пользователь не имеет прав", typeof(string))]
        [SwaggerResponse(400, "Ошибка при создании кандидата", typeof(string))]
        [Obsolete("DTO только для общения между слоями и в ответ, DTO не может быть запросом")]
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

        /*[HttpPut("update-candidate")]
        [Authorize(Roles = "HR")]
        [SwaggerOperation(Summary = "Обновление данных кандидата", Description = "Обновляет данные кандидата по ID")]
        [SwaggerResponse(200, "Кандидат успешно обновлен", typeof(CandidateDTO))]
        [SwaggerResponse(400, "Ошибка при обновлении кандидата", typeof(string))]
        [SwaggerResponse(401, "Пользователь не имеет прав", typeof(string))]
        [SwaggerResponse(404, "Кандидат не найден", typeof(string))]
        public async Task<IActionResult> UpdateCandidate([FromQuery] CandidateCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _candidateService.UpdateCandidateAsync(request, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("не найден"))
                {
                    return NotFound($"Кандидат с таким ID не найден.");
                }
                return BadRequest($"Ошибка: {ex.Message}");
            }
        }*/
    }
}
