using Announcements.Domain.Entities.Shared;
using System;
using System.Collections.Generic;

namespace Announcements.Domain.Entities
{

    /// <summary>
    /// Объявление
    /// </summary>
    public sealed class Announcement : MutableEntity<int>
    {
        /// <summary>
        /// Заголовок объявления
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// Текст объявления
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// id региона к которому принадлежит объявление
        /// </summary>
        public int? RegionID { get; set; }
        public Region Region { get; set; }


        /// <summary>
        /// Цена услуги или товара
        /// </summary>
        public decimal? Price { get; set; }


        /// <summary>
        /// id категории к которой принадлежит объявление
        /// </summary>
        public int? CategoryID { get; set; }
        public Category Category { get; set; }


        /// <summary>
        /// id владельца объявления
        /// </summary>
        public string OwnerID { get; set; }
        public User Owner { get; set; }


        /// <summary>
        /// Дата публикации объявления
        /// </summary>
        public DateTime PublishDate { get; set; }


        /// <summary>
        /// статус объявления
        /// </summary>
        public AnnouncementStatus Status { get; set; }


        /// <summary>
        /// Комментарии к объявлению
        /// </summary>
        public ICollection<Comment> Comments { get; set; }


        /// <summary>
        /// Файлы объявления
        /// </summary>
        public ICollection<AnnouncementFile> AnnouncementFiles { get; set; }

    }
}
