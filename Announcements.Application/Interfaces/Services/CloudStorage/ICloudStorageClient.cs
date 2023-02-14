using Announcements.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Announcements.Application.Interfaces.Services.CloudStorage
{
    /// <summary>
    /// Клиент облачного хранилища
    /// </summary>
    public interface ICloudStorageClient
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        Task Login();


        /// <summary>
        /// Получить URI аватара пользователя
        /// </summary>
        Task<Uri> GetUserAvatarUri(UserFile userFile);


        /// <summary>
        /// Загрузить аватар пользователя
        /// </summary>
        Task<string> UploadUserAvatar(IFormFile userFile);


        /// <summary>
        /// Логаут пользователя
        /// </summary>
        Task Logout();


        /// <summary>
        /// Загрузить фото к объявлению
        /// </summary>
        Task<List<string>> UploadAnnouncementImages(List<IFormFile> announcementFiles);


        /// <summary>
        /// Получить URI фото объявления
        /// </summary>
        Task<List<Uri>> GetAnnouncementImagesURIs(IEnumerable<AnnouncementFile> announcementFiles);


        /// <summary>
        /// Получить URI конкретного фото объявления
        /// </summary>
        Task<Uri> GetAnnouncementImageURI(AnnouncementFile announcementFile);


        /// <summary>
        /// Получить имя файла по URI
        /// </summary>
        Task<string> GetFileName(Uri fileUri);

    }

}
