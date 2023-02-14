using Announcements.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Interfaces.Repositories
{
    /// <summary>
    /// Интерфейс репозитория файлов объявления
    /// </summary>
    public interface IAnnouncementFileRepository : IRepository<AnnouncementFile, int>
    {

        /// <summary>
        /// Найти изображения по id объявления
        /// </summary>
        public Task<IEnumerable<AnnouncementFile>> FindImagesByAnnouncementId(int announcementId, CancellationToken cancellationToken);


        /// <summary>
        /// Удалить изображения по id объявления
        /// </summary>
        Task DeleteAnnouncementImages(int userId, CancellationToken cancellationToken);


        /// <summary>
        /// Удалить изображение объявления
        /// </summary>
        Task DeleteAnnouncementImage(int announcementId, string announcementFileName, CancellationToken cancellationToken);


        /// <summary>
        /// Найти главное изображение объявления
        /// </summary>
        public Task<AnnouncementFile> FindAnnouncementFaceImage(int announcementId, CancellationToken cancellationToken);

    }
}
