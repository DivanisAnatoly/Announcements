using Announcements.Application.Identity.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Identity.Interfaces
{
    /// <summary>
    /// Интерфейс Identity сервиса
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Получить id текущего пользователя
        /// </summary>
        Task<string> GetCurrentUserId(CancellationToken cancellationToken);


        /// <summary>
        /// Проверить роль пользователя
        /// </summary>
        Task<bool> IsInRole(string userId, string role, CancellationToken cancellationToken);


        /// <summary>
        /// Создать Identity пользователя
        /// </summary>
        Task<CreateIdentityUserDTO.Response> CreateUser(CreateIdentityUserDTO.Request request, CancellationToken cancellationToken);


        /// <summary>
        /// Залогинить пользователя
        /// </summary>
        Task<LoginIdentityUserDTO.Response> LoginUser(LoginIdentityUserDTO.Request request, CancellationToken cancellationToken);

        /// <summary>
        /// Подтвердить почту
        /// </summary>
        Task<bool> ConfirmEmail(string userId, string token, CancellationToken cancellationToken);

    }
}
