using Announcements.Application.RequestModels;
using Announcements.Domain.Entities;
using Announcements.Domain.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Interfaces.Repositories
{
    /// <summary>
    /// Интерфейс репозитория пользователей
    /// </summary>
    public interface IUserRepository : IRepository<User, string>
    {

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        Task Delete(string id, CancellationToken cancellationToken);


        /// <summary>
        /// Получить страницу с пользователями
        /// </summary>
        Task<PagedList<User>> GetPaged(GetPagedUsersRequest request, CancellationToken cancellationToken);

    }
}
