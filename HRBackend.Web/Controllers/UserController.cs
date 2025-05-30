using HRBackend.Application.Request;
using HRBackend.Application.DTO;
using HRBackend.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using HRBackend.Application.Services;

namespace HRBackend.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;    // Твой сервис работы с пользователями
        private readonly JwtService _jwtService;

        public UserController(IUserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

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
                // Вызов сервиса напрямую
                await _userService.RegisterUserAsHRAsync(request, cancellationToken);
                return Ok("Пользователь успешно создан");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Пользователь с таким логином уже существует"))
                    return BadRequest(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("authorize")]
        [SwaggerOperation(Summary = "Авторизация", Description = "Происходит авторизация, возвращается JWT токен")]
        public async Task<IActionResult> Login([FromQuery] LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Получаем DTO пользователя через сервис
                UserDTO userDTO = await _userService.AuthenticateUserAsync(request.Login, request.Password, cancellationToken);

                if (userDTO == null)
                {
                    return BadRequest("Неверный логин или пароль");
                }

                var accessToken = _jwtService.GenerateAccessToken(userDTO.Id, userDTO.Login, userDTO.Role);
                var refreshToken = _jwtService.GenerateRefreshToken();

                return Ok(new { accessToken, refreshToken });
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка авторизации: {ex.Message}");
            }
        }
    }
}
