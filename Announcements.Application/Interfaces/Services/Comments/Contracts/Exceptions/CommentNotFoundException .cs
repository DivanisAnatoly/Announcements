using Announcements.Domain.Exceptions;

namespace Announcements.Application.Interfaces.Services.Comments.Contracts.Exceptions
{
    /// <summary>
    /// Комментарий не найден
    /// </summary>
    public sealed class CommentNotFoundException : NotFoundException
    {
        public CommentNotFoundException(string message) : base(message) { }
    }
}
