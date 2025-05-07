using MediatR;
using HRBackend.Application.Request;
using HRBackend.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace HRBackend.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtService _jwtService;

        public UserController(IMediator mediator, JwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        // Регистрация пользователя с ролью HR
        [HttpPost("register-hr")]
        [Authorize(Roles = "Admin")]
        [Produces(typeof(string))]
        [SwaggerOperation(Summary = "Регистрация HR", Description = "Создает нового пользователя с ролью HR")]
        [SwaggerResponse(200, "Успешно создан новый HR", typeof(string))]
        [SwaggerResponse(400, "Пользователь с таким логином уже существует", typeof(string))]
        [SwaggerResponse(401, "Пользователь не имеет прав", typeof(string))]
        public async Task<IActionResult> RegisterUserHR([FromQuery] RegisterUserHRRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(request, cancellationToken);
                return Ok("Пользователь успешно создан");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Пользователь с таким логином уже существует"))
                {
                    return BadRequest(ex.Message);
                }
                return BadRequest(ex.Message);
            }
        }

        // Авторизация пользователя и получение токена
        [HttpPost("authorize")]
        [SwaggerOperation(Summary = "Авторизация", Description = "Происходит авторизация, возвращается JWT токен")]
        public async Task<IActionResult> Login([FromQuery] LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userDTO = await _mediator.Send(request, cancellationToken);
                var accessToken = _jwtService.GenerateAccessToken(userDTO.Id, userDTO.Login, userDTO.Role);
                var refreshToken = _jwtService.GenerateRefreshToken();
                return Ok(new { accessToken, refreshToken });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}