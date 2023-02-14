using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Interfaces.Services.Files
{
    /// <summary>
    /// Интерфейс файлового сервиса
    /// </summary>
    public interface IFileService
    {

        /// <summary>
        /// Загрузить аватар пользователя
        /// </summary>
        Task UploadUserAvatar(string userID, IFormFile UserAvatar, CancellationToken cancellationToken);


        /// <summary>
        /// Получить аватар пользователя
        /// </summary>
        Task<Uri> GetUserAvatar(string userID, CancellationToken cancellationToken);


        /// <summary>
        /// Удалить аватар пользователя (смена статуса)
        /// </summary>
        Task DeleteUserAvatar(string userID, CancellationToken cancellationToken);


        /// <summary>
        /// Обновить автарку
        /// </summary>
        Task UpdateUserAvatar(string iD, IFormFile userAvatar, CancellationToken cancellationToken);


        /// <summary>
        /// Загрузить фотографии к объявлению
        /// </summary>
        Task UploadAnnouncementImages(int announcementID, List<IFormFile> announcementFiles, CancellationToken cancellationToken);


        /// <summary>
        /// Получить фото объявления
        /// </summary>
        Task<List<Uri>> GetAnnouncementImages(int announcementID, CancellationToken cancellationToken);


        /// <summary>
        /// Получить лицевое фото объявления
        /// </summary>
        Task<Uri> GetAnnouncementFaceImage(int announcementID, CancellationToken cancellationToken);


        /// <summary>
        /// Удалить изображения объявления (смена статуса)
        /// </summary>
        Task DeleteAnnouncementImages(int announcementID, CancellationToken cancellationToken);


        /// <summary>
        /// Удалить перечень изображений объявления
        /// </summary>
        Task DeleteAnnouncementImages(int announcementID, List<Uri> announcementFilesURI, CancellationToken cancellationToken);

    }
}
