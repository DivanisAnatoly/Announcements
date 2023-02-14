using Announcements.Application.RequestModels.Announcement;
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
    public interface IAnnouncementRepository : IRepository<Announcement, int>
    {

        /// <summary>
        /// Удалить объявление
        /// </summary>
        Task<bool> DeleteAnnouncement(int id, CancellationToken cancellationToken);


        /// <summary>
        /// Возвращает все объявления
        /// </summary>
        Task<IEnumerable<Announcement>> GetAllAnnouncemets(CancellationToken cancellationToken);


        /// <summary>
        /// Получить страницу с объявлениями
        /// </summary>
        Task<PagedList<Announcement>> GetPaged(GetPagedAnnouncementsRequest request, CancellationToken cancellationToken);

    }
}
