using Announcements.Domain.Exceptions;

namespace Announcements.Application.Interfaces.Services.Users.Contracts.Exceptions
{
    /// <summary>
    /// Нет прав на редактирование пользователя
    /// </summary>
    public sealed class UserNoRightsToEditException : NoRightsException
    {
        public UserNoRightsToEditException(string message) : base(message) { }
    }
}
