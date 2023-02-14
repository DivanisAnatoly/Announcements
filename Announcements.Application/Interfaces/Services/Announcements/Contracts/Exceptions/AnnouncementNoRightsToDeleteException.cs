using Announcements.Domain.Exceptions;

namespace Announcements.Application.Interfaces.Services.Announcements.Contracts.Exceptions
{
    /// <summary>
    /// Пользователь не найден
    /// </summary>
    public sealed class AnnouncementsNoRightsToDeleteException : NoRightsException
    {
        public AnnouncementsNoRightsToDeleteException(string message) : base(message) { }
    }
}
