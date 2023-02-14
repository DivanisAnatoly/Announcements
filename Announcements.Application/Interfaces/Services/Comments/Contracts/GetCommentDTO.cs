using System;

namespace Announcements.Application.Interfaces.Services.Comments.Contracts
{
    /// <summary>
    /// Модель получения объявления по айди
    /// </summary>
    public static class GetCommentDTO
    {
        public sealed class Response
        {
            ///<inheritdoc cref="BaseEntity.ID"/>
            public int ID { get; set; }


            ///<inheritdoc cref="Domain.Entities.Comment.Text"/>
            public string Text { get; set; }


            ///<inheritdoc cref="Domain.Entities.Comment.AuthorID"/>
            public string AuthorID { get; set; }

            /// <summary>
            /// Имя автора
            /// </summary>
            public string AuthorName { get; set; }


            /// <summary>
            /// Аватар автора
            /// </summary>
            public Uri AuthorAvatarUri { get; set; }


            ///<inheritdoc cref="Domain.Entities.Comment.AnnouncementID"/>
            public int AnnouncementID { get; set; }

        }

    }
}
