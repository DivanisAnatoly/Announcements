using Announcements.Application.RequestModels.Comment;
using Announcements.Domain.Entities;
using Announcements.Domain.Helpers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Interfaces.Repositories
{

    /// <summary>
    /// Интерфейс репозитория объявлений
    /// </summary>
    public interface ICommentRepository : IRepository<Comment, int>
    {
        /// <summary>
        /// Удалить объявление
        /// </summary>
        Task DeleteComment(int id, CancellationToken cancellationToken);


        /// <summary>
        /// Получить все комментарии
        /// </summary>
        Task<IEnumerable<Comment>> GetAllComments(CancellationToken cancellationToken);


        /// <summary>
        /// Получить комментарии объявления
        /// </summary>
        public Task<PagedList<Comment>> GetAnnouncementComments(int announcementID, GetPagedCommentsRequest request, CancellationToken cancellationToken);

    }
}
