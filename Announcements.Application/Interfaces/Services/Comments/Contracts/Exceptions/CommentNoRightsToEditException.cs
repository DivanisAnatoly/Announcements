using Announcements.Domain.Exceptions;

namespace Announcements.Application.Interfaces.Services.Comments.Contracts.Exceptions
{
    /// <summary>
    /// Нет прав на редактирование комментария
    /// </summary>
    public sealed class CommentNoRightsToEditException : NoRightsException
    {
        public CommentNoRightsToEditException(string message) : base(message) { }
    }
}
