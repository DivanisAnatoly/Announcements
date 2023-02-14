using Announcements.Domain.Entities.Shared;
using System;



namespace Announcements.Domain.Entities
{
    /// <summary>
    /// Коментарий
    /// </summary>
    public sealed class Comment : MutableEntity<int>
    {
        /// <summary>
        /// Текст коментария
        /// </summary>
        public string Text { get; set; }


        /// <summary>
        /// id автора коментария
        /// </summary>
        public string AuthorID { get; set; }
        public User Author { get; set; }


        /// <summary>
        /// id объявления к которому принадлежит коментарий
        /// </summary>
        public int AnnouncementID { get; set; }
        public Announcement Announcement { get; set; }


        /// <summary>
        /// Дата публикации
        /// </summary>
        public DateTime PublishDate { get; set; }


        /// <inheritdoc cref="CommentStatus"/>
        public CommentStatus Status { get; set; }
    }
}
