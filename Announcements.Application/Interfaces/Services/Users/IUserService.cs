using Announcements.Application.Interfaces.Services.Users.Contracts;
using Announcements.Application.RequestModels;
using Announcements.Domain.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Interfaces.Services.Users
{
    /// <summary>
    /// Интерфейс сервиса пользователей
    /// </summary>
    public interface IUserService
    {

        /// <summary>
        /// Получить информацию о пользователях постранично
        /// </summary>
        Task<PagedList<UserPageItem>> GetUsersPaged(GetPagedUsersRequest request, CancellationToken cancellationToken);


        /// <summary>
        /// Получить информацию о пользователе по id
        /// </summary>
        Task<GetUserDTO.Response> GetUser(string id, CancellationToken cancellationToken);


        /// <summary>
        /// Зарегистрировать пользователя
        /// </summary>
        Task<RegisterUserDTO.Response> Register(RegisterUserDTO.Request request, CancellationToken cancellationToken);


        /// <summary>
        /// Редактировать информацию о пользователе
        /// </summary>
        Task<EditUserDTO.Response> Update(EditUserDTO.Request request, CancellationToken cancellationToken);


        /// <summary>
        /// Удалить пользователя
        /// </summary>
        Task DeleteUser(string id, CancellationToken cancellationToken);

    }
}
