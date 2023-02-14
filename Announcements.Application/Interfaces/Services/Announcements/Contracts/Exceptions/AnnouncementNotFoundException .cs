using Announcements.Domain.Exceptions;

namespace Announcements.Application.Interfaces.Services.Announcements.Contracts.Exceptions
{
    /// <summary>
    /// Объявление не найдено
    /// </summary>
    public sealed class AnnouncementNotFoundException : NotFoundException
    {
        public AnnouncementNotFoundException(string message) : base(message) { }
    }
}
