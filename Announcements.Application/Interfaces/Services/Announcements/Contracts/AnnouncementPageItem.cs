using Announcements.Domain.Entities;
using Announcements.Domain.Entities.Shared;
using System;

namespace Announcements.Application.Interfaces.Services.Announcements.Contracts
{
    public class AnnouncementPageItem
    {
        ///<inheritdoc cref="BaseEntity.ID"/>
        public int ID { get; set; }


        ///<inheritdoc cref="Announcement.Title"/>
        public string Title { get; set; }


        ///<inheritdoc cref="Announcement.RegionID"/>
        public int? RegionID { get; set; }


        ///<inheritdoc cref="Region.Name"/>
        public string Region { get; set; }


        ///<inheritdoc cref="Announcement.Price"/>
        public decimal? Price { get; set; }


        ///<inheritdoc cref="Announcement.CategoryID"/>
        public int? CategoryID { get; set; }


        ///<inheritdoc cref="Category.Name"/>
        public string Category { get; set; }


        /// <summary>
        /// Основное фото объявления
        /// </summary>
        public Uri AnnouncementFaceImageUri { get; set; }

    }

}
