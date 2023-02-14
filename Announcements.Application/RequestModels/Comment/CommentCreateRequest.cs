namespace Announcements.Application.RequestModels
{
    /// <summary>
    /// Модель создания комментария
    /// </summary>
    public sealed class CommentCreateRequest
    {
        ///<inheritdoc cref="Domain.Entities.Comment.Text"/>
        public string Text { get; set; }


        ///<inheritdoc cref="Domain.Entities.Comment.AnnouncementID"/>
        public int AnnouncementID { get; set; }

    }
}
