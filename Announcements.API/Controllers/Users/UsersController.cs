using Announcements.Application.Identity.Contracts;
using Announcements.Application.Identity.Interfaces;
using Announcements.Application.Interfaces.Services.Users;
using Announcements.Application.Interfaces.Services.Users.Contracts;
using Announcements.Application.RequestModels;
using Announcements.Application.RequestModels.User.Validators;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Announcements.API.Controllers.Users
{

    /// <summary>
    /// Контроллер пользователей
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор контроллера пользователей
        /// </summary>
        public UsersController(IUserService userService, IMapper mapper, IIdentityService identityService)
        {
            _userService = userService;
            _mapper = mapper;
            _identityService = identityService;
        }


        /// <summary>
        /// Логинит пользователя
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest identityLoginRequest, CancellationToken cancellationToken)
        {
            LoginIdentityUserDTO.Request request = _mapper.Map<LoginIdentityUserDTO.Request>(identityLoginRequest);
            var loginResponse = await _identityService.LoginUser(request, cancellationToken);
            return Ok(new { access_token = loginResponse.Token});
        }


        /// <summary>
        /// Возвращает пользователей постранично
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPagedUsers([FromQuery] GetPagedUsersRequest request, CancellationToken cancellationToken)
        {
            var usersPage = await _userService.GetUsersPaged(request, cancellationToken);

            var metadata = new
            {
                usersPage.TotalCount,
                usersPage.PageSize,
                usersPage.CurrentPage,
                usersPage.TotalPages,
                usersPage.HasNext,
                usersPage.HasPrevious
            };

            Response.Headers.Add("User-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(usersPage);
        }


        /// <summary>
        /// Возвращает пользователя по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(string id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUser(id, cancellationToken);
            return Ok(user);
        }


        /// <summary>
        /// Регистрирует пользователя
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest userRegisterRequest, CancellationToken cancellationToken)
        {
            UserRegisterRequestValidator validator = new();
            var result = await validator.ValidateAsync(userRegisterRequest, cancellationToken);

            if (!result.IsValid)
            {
                string errors = string.Join(';', result.Errors.Select(x => x.ErrorMessage));
                return BadRequest(errors); 
            }

            RegisterUserDTO.Request request = _mapper.Map<RegisterUserDTO.Request>(userRegisterRequest);
            var response = await _userService.Register(request, cancellationToken);
            return Ok(response);
        }


        /// <summary>
        /// Редактировать информацию о пользователе
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> EditUser([FromForm] UserEditRequest editRequest, CancellationToken cancellationToken)
        {
            EditUserDTO.Request request = _mapper.Map<EditUserDTO.Request>(editRequest);
            var response = await _userService.Update(request, cancellationToken);
            return Ok(response);
        }


        /// <summary>
        /// Удаляет пользователя
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteUser(string id, CancellationToken cancellationToken)
        {
            await _userService.DeleteUser(id, cancellationToken);
            return Ok("User was successfully deleted");
        }


        /// <summary>
        /// Подтверждение почты
        /// </summary>
        [HttpGet("Confirm")]
        public async Task<IActionResult> Confirm(string userId, string token, CancellationToken cancellationToken)
        {
            var isSuccessful = await _identityService.ConfirmEmail(userId, token, cancellationToken);
            if (isSuccessful)
            {
                return Ok("Почта подтверждена");
            }

            return BadRequest("Неправильный токен или идентификатор пользователя");
        }

    }
}
