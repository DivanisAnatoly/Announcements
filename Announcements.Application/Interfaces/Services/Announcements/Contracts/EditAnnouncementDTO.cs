using Announcements.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Announcements.Application.Interfaces.Services.Announcements.Contracts
{
    /// <summary>
    /// Модель редактирования объявления
    /// </summary>
    public static class EditAnnouncementDTO
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
            /// Удаленные файлы объявления
            /// </summary>
            public List<Uri> DeletedAnnouncementFiles { get; set; }


            /// <summary>
            /// Новые файлы объявления
            /// </summary>
            public List<IFormFile> NewAnnouncementFiles { get; set; }
        }


        public sealed class Response
        {
            ///<inheritdoc cref="BaseEntity.ID"/>
            public int ID { get; set; }

        }

    }
}
