namespace Announcements.Application.Interfaces.Services.Comments.Contracts
{
    /// <summary>
    /// Модель редактирования объявления
    /// </summary>
    public static class EditCommentDTO
    {
        public sealed class Request
        {
            ///<inheritdoc cref="Domain.Entities.Comment.Text"/>
            public string Text { get; set; }

        }


        public sealed class Response
        {
            ///<inheritdoc cref="BaseEntity.ID"/>
            public int ID { get; set; }

        }

    }
}
