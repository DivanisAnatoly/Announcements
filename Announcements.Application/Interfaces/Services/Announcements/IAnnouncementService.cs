using Announcements.Application.Interfaces.Services.Announcements.Contracts;
using Announcements.Application.Interfaces.Services.Comments.Contracts;
using Announcements.Application.RequestModels.Announcement;
using Announcements.Application.RequestModels.Comment;
using Announcements.Domain.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Interfaces.Services.Announcements
{
    /// <summary>
    /// Интерфейс сервиса объявлений
    /// </summary>
    public interface IAnnouncementService
    {

        /// <summary>
        /// Получить информацию о пользователях постранично
        /// </summary>
        Task<PagedList<AnnouncementPageItem>> GetAnnouncementsPaged(GetPagedAnnouncementsRequest request, CancellationToken cancellationToken);


        /// <summary>
        /// Получить комментарии к объявлению постранично
        /// </summary>
        Task<PagedList<CommentPageItem>> GetAnnouncementCommentsPaged(int announcementID, GetPagedCommentsRequest request, CancellationToken cancellationToken);


        /// <summary>
        /// Создать объявление
        /// </summary>
        Task<CreateAnnouncementDTO.Response> CreateAnnouncement(CreateAnnouncementDTO.Request createAnnouncements, CancellationToken cancellationToken);


        /// <summary>
        /// Получить объявление по id
        /// </summary>
        Task<GetAnnouncementDTO.Response> GetAnnouncement(int id, CancellationToken cancellationToken);


        /// <summary>
        /// Редактировать информацию об объявлении
        /// </summary>
        Task<EditAnnouncementDTO.Response> EditAnnouncement(int userID, EditAnnouncementDTO.Request request, CancellationToken cancellationToken);


        /// <summary>
        /// Удалить объявление
        /// </summary>
        Task DeleteAnnouncement(int id, CancellationToken cancellationToken);

    }
}
