using Announcements.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Announcements.Application.Interfaces.Services.Announcements.Contracts
{
    /// <summary>
    /// Модель регистрации объявления
    /// </summary>
    public static class CreateAnnouncementDTO
    {
        public sealed class Request
        {
            ///<inheritdoc cref="Announcement.Title"/>
            public string Title { get; set; }


            ///<inheritdoc cref="Announcement.Description"/>
            public string Description { get; set; }


            ///<inheritdoc cref="Announcement.RegionID"/>
            public int? RegionID { get; set; }


            ///<inheritdoc cref="Announcement.Price"/>
            public decimal? Price { get; set; }


            ///<inheritdoc cref="Announcement.CategoryID"/>
            public int? CategoryID { get; set; }


            /// <summary>
            /// Файлы объявления
            /// </summary>
            public List<IFormFile> AnnouncementImages { get; set; }

        }

        public class Response
        {
            ///<inheritdoc cref="BaseEntity.ID"/>
            public int ID { get; set; }
        }
    }
}
