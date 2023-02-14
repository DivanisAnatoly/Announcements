using Announcements.Domain.Exceptions;

namespace Announcements.Application.Interfaces.Services.Users.Contracts.Exceptions
{
    public class IdentityUserNotFoundException : NotFoundException
    {
        public IdentityUserNotFoundException(string message) : base(message)
        {
        }
    }
}
