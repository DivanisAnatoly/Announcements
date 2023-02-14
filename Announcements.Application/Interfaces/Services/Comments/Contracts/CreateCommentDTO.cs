namespace Announcements.Application.Interfaces.Services.Comments.Contracts
{
    /// <summary>
    /// Модель регистрации объявления
    /// </summary>
    public static class CreateCommentDTO
    {
        public sealed class Request
        {
            ///<inheritdoc cref="Domain.Entities.Comment.Text"/>
            public string Text { get; set; }


            ///<inheritdoc cref="Domain.Entities.Comment.AnnouncementID"/>
            public int AnnouncementID { get; set; }

        }

        public class Response
        {
            ///<inheritdoc cref="BaseEntity.ID"/>
            public int ID { get; set; }
        }

    }
}
