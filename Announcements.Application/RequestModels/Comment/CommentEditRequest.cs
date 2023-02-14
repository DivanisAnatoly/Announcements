namespace Announcements.Application.RequestModels
{

    /// <summary>
    /// Модель редактирования комментария
    /// </summary>
    public sealed class CommentEditRequest
    {
        ///<inheritdoc cref="BaseEntity.ID"/>
        public int ID { get; set; }


        ///<inheritdoc cref="Domain.Entities.Comment.Text"/>
        public string Text { get; set; }

    }
}
