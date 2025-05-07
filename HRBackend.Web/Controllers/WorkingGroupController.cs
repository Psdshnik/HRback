using HRBackend.Application.DTO;
using HRBackend.Application.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace HRBackend.Web.Controllers
{
    [Route("api/working-groups")]
    [ApiController]
    public class WorkingGroupController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtService _jwtService;

        public WorkingGroupController(IMediator mediator, JwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }


        [HttpPost("create-group")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Создание рабочей группы", Description = "Создает новую рабочую группу")]
        [SwaggerResponse(200, "Рабочая группа успешно создана", typeof(string))]
        [SwaggerResponse(400, "Рабочая группа с таким именем уже существует", typeof(string))]
        [SwaggerResponse(401, "Пользователь не имеет прав", typeof(string))]
        public async Task<IActionResult> CreateWorkingGroup([FromQuery] WorkingGroupRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Рабочая группа с таким именем уже существует"))
                {
                    return BadRequest(ex.Message);
                }

                return BadRequest(ex.Message);
            }
        }


        [HttpPut("update-group")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Обновление рабочей группы", Description = "Обновляет рабочую группу по ID")]
        [SwaggerResponse(200, "Рабочая группа успешно обновлена", typeof(WorkingGroupDTO))]
        [SwaggerResponse(400, "Ошибка обновления рабочей группы", typeof(string))]
        [SwaggerResponse(404, "Рабочая группа не найдена", typeof(string))]
        public async Task<IActionResult> UpdateWorkingGroup([FromQuery] UpdateWorkingGroupRequest request,CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("не найдена"))
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-group")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Удаление рабочей группы", Description = "Удаляет рабочую группу по ID")]
        [SwaggerResponse(200, "Рабочая группа успешно удалена", typeof(bool))]
        [SwaggerResponse(400, "Ошибка удаления рабочей группы", typeof(string))]
        [SwaggerResponse(404, "Рабочая группа не найдена", typeof(string))]
        public async Task<IActionResult> DeleteWorkingGroup([FromQuery] int id,CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new DeleteWorkingGroupRequest { Id = id }, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("не найдена"))
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }
        }
    }
}
