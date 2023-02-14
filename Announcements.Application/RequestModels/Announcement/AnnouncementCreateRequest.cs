using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Announcements.Application.RequestModels
{
    /// <summary>
    /// Модель создания объявления
    /// </summary>
    public sealed class AnnouncementCreateRequest
    {

        ///<inheritdoc cref="Domain.Entities.Announcement.Title"/>
        public string Title { get; set; }


        ///<inheritdoc cref="Domain.Entities.Announcement.Description"/>
        public string Description { get; set; }


        ///<inheritdoc cref="Domain.Entities.Announcement.RegionID"/>
        public int? RegionID { get; set; }


        ///<inheritdoc cref="Domain.Entities.Announcement.Price"/>
        public decimal? Price { get; set; }


        ///<inheritdoc cref="Domain.Entities.Announcement.CategoryID"/>
        public int? CategoryID { get; set; }


        /// <summary>
        /// Файлы объявления
        /// </summary>
        public List<IFormFile> AnnouncementImages { get; set; }

    }
}
