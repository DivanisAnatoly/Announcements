using Announcements.Domain.Exceptions;

namespace Announcements.Application.Interfaces.Services.Announcements.Contracts.Exceptions
{
    /// <summary>
    /// Нет прав редактировать объявление
    /// </summary>
    public sealed class AnnouncementsNoRightsToEditException : NoRightsException
    {
        public AnnouncementsNoRightsToEditException(string message) : base(message) { }
    }
}
