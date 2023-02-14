using Announcements.Domain.Exceptions;

namespace Announcements.Application.Interfaces.Services.Users.Contracts.Exceptions
{
    /// <summary>
    /// Нет прав на удаление пользователя
    /// </summary>
    public sealed class UserNoRightsToDeleteException : NoRightsException
    {
        public UserNoRightsToDeleteException(string message) : base(message) { }
    }
}
