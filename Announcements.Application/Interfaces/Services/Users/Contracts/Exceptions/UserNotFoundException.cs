using Announcements.Domain.Exceptions;

namespace Announcements.Application.Interfaces.Services.Users.Contracts.Exceptions
{
    /// <summary>
    /// Пользователь не найден
    /// </summary>
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string message) : base(message) { }
    }
}
