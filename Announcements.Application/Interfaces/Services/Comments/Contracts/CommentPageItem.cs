using System;

namespace Announcements.Application.Interfaces.Services.Comments.Contracts
{
    public class CommentPageItem
    {
        ///<inheritdoc cref="BaseEntity.ID"/>
        public int ID { get; set; }


        /// <inheritdoc cref="Domain.Entities.Comment.Text"/>
        public string Text { get; set; }


        /// <inheritdoc cref="Domain.Entities.Comment.AuthorID"/>
        public string AuthorID { get; set; }


        /// <summary>
        /// Имя автора 
        /// </summary>
        public string AuthorName { get; set; }


        /// <summary>
        /// Аватар автора
        /// </summary>
        public Uri UserAvatarUri { get; set; }


        /// <inheritdoc cref="Domain.Entities.Comment.PublishDate"/>
        public DateTime PublishDate { get; set; }

    }
}
