using Announcements.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Interfaces.Repositories
{
    /// <summary>
    /// Интерфейс репозитория файлов пользователей
    /// </summary>
    public interface IUserFileRepository : IRepository<UserFile, int>
    {

        /// <summary>
        /// Найти аватар по id пользователя
        /// </summary>
        Task<UserFile> FindAvatarByUserId(string userId, CancellationToken cancellationToken);


        /// <summary>
        /// Удалить пользовательский аватар
        /// </summary>
        Task DeleteUserAvatar(string userId, CancellationToken cancellationToken);

    }
}
