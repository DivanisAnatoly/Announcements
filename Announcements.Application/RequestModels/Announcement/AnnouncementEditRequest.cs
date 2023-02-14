using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Announcements.Application.RequestModels
{

    /// <summary>
    /// Модель редактирования объявления
    /// </summary>
    public sealed class AnnouncementEditRequest
    {

        ///<inheritdoc cref="BaseEntity.ID"/>
        public int ID { get; set; }


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
        /// Удаленные файлы объявления
        /// </summary>
        public List<Uri> DeletedAnnouncementFiles { get; set; }


        /// <summary>
        /// Новые файлы объявления
        /// </summary>
        public List<IFormFile> NewAnnouncementFiles { get; set; }
    }
}
