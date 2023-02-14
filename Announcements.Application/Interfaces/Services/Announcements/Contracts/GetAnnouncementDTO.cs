using Announcements.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Announcements.Application.Interfaces.Services.Announcements.Contracts
{
    /// <summary>
    /// Модель получения объявления по айди
    /// </summary>
    public static class GetAnnouncementDTO
    {
        public sealed class Response
        {

            ///<inheritdoc cref="Announcement.Title"/>
            public string Title { get; set; }


            ///<inheritdoc cref="Announcement.Description"/>
            public string Description { get; set; }


            ///<inheritdoc cref="Announcement.Price"/>
            public decimal? Price { get; set; }


            ///<inheritdoc cref="Announcement.RegionID"/>
            public int? RegionID { get; set; }


            ///<inheritdoc cref="Region.Name"/>
            public string Region { get; set; }


            ///<inheritdoc cref="Announcement.CategoryID"/>
            public int? CategoryID { get; set; }


            ///<inheritdoc cref="Category.Name"/>
            public string Category { get; set; }


            ///<inheritdoc cref="Announcement.OwnerID"/>
            public string OwnerID { get; set; }


            /// <summary>
            /// Имя владельца объявления
            /// </summary>
            public string OwnerName { get; set; }


            /// <summary>
            /// Фото объявления
            /// </summary>
            public List<Uri> AnnouncementImagesUri { get; set; }

        }

    }
}
