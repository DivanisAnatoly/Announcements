using Announcements.Application.Common;
using Announcements.Application.Identity.Contracts;
using Announcements.Application.Identity.Interfaces;
using Announcements.Application.Interfaces.Repositories;
using Announcements.Application.Interfaces.Services.Mail;
using Announcements.Application.Interfaces.Services.Users;
using Announcements.Application.Interfaces.Services.Users.Contracts.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Announcements.Infrastructure.Identity
{
    ///<inheritdoc cref="IIdentityService"/>
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;


        /// <summary>
        /// Конструктор
        /// </summary>
        public IdentityService(IHttpContextAccessor httpContextAccessor, UserManager<AppIdentityUser> userManager,
            ITokenGenerator tokenGenerator, IUserRepository userRepository, IConfiguration configuration,
            IMailService mailService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
            _configuration = configuration;
            _mailService = mailService;
        }


        ///<inheritdoc/>
        public async Task<bool> ConfirmEmail(string userId, string token, CancellationToken cancellationToken)
        {
            var identityUser = await _userManager.FindByIdAsync(userId);
            if (identityUser == null)
            {
                throw new IdentityUserNotFoundException("Пользователь не найден");
            }

            var result = await _userManager.ConfirmEmailAsync(identityUser, token);

            return result.Succeeded;
        }


        ///<inheritdoc/>
        public async Task<LoginIdentityUserDTO.Response> LoginUser(LoginIdentityUserDTO.Request request, CancellationToken cancellationToken)
        {
            var identityUser = await _userManager.FindByEmailAsync(request.Email);
            if (identityUser == null)
            {
                throw new IdentityUserNotFoundException("Пользователь не найден");
            }

            var domainUser = await _userRepository.FindById(identityUser.Id, cancellationToken);
            if (domainUser?.Status == Domain.Entities.UserStatus.Deleted)
            {
                throw new IdentityUserNotFoundException("Пользователь не найден");
            }

            var passwordCheckResult = await _userManager.CheckPasswordAsync(identityUser, request.Password);

            if (!passwordCheckResult)
            {
                throw new Exception("Неправильный логин или пароль");
            }

            bool isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(identityUser);

            if (!isEmailConfirmed)
            {
                throw new Exception("Почта не подтверждена");
            }

            var myClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, identityUser.Email),
                new Claim(ClaimTypes.NameIdentifier, identityUser.Id),
            };

            var userRoles = await _userManager.GetRolesAsync(identityUser);
            myClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            return new LoginIdentityUserDTO.Response
            {
                Token = await _tokenGenerator.ReceiveTokenFromClaims(myClaims, cancellationToken)
            };
        }


        ///<inheritdoc/>
        public async Task<CreateIdentityUserDTO.Response> CreateUser(CreateIdentityUserDTO.Request request, CancellationToken cancellationToken)
        {
            var existedUser = await _userManager.FindByEmailAsync(request.Email);
            if (existedUser != null)
            {
                throw new Exception("Пользователь с такой почтой уже существует");
            }

            var identityUser = new AppIdentityUser
            {
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            var identityResult = await _userManager.CreateAsync(identityUser, request.Password);

            if (identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(identityUser, RoleConstants.UserRole);
                var confirmationEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                var encodedToken = HttpUtility.UrlEncode(confirmationEmailToken);
                var message = $"<a href=\"{_configuration["ApiUri"]}api/v1/Users/confirm?userId={identityUser.Id}&token={encodedToken}\">Нажми меня</a>";

                await _mailService.Send(request.Email, "Подтверди почту!", message, cancellationToken);

                return new CreateIdentityUserDTO.Response
                {
                    ID = identityUser.Id,
                    IsSuccess = true
                };
            }

            return new CreateIdentityUserDTO.Response
            {
                IsSuccess = false,
            };
        }


        ///<inheritdoc/>
        public Task<string> GetCurrentUserId(CancellationToken cancellationToken)
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
            return Task.FromResult(_userManager.GetUserId(claimsPrincipal));
        }


        ///<inheritdoc/>
        public async Task<bool> IsInRole(string userId, string role, CancellationToken cancellationToken)
        {
            var appIdentityUser = await _userManager.FindByIdAsync(userId);
            if (appIdentityUser == null)
            {
                throw new IdentityUserNotFoundException("Пользователь не найден");
            }

            return await _userManager.IsInRoleAsync(appIdentityUser, role);
        }

    }

}
