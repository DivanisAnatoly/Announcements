using Announcements.Domain.Exceptions;

namespace Announcements.Application.Interfaces.Services.Comments.Contracts.Exceptions
{
    /// <summary>
    /// Нет прав на удаление комментария
    /// </summary>
    public sealed class CommentNoRightsToDeleteException : NoRightsException
    {
        public CommentNoRightsToDeleteException(string message) : base(message) { }
    }
}
