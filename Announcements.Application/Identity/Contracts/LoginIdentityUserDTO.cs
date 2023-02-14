using Announcements.Domain.Entities;

namespace Announcements.Application.Identity.Contracts
{
    public static class LoginIdentityUserDTO
    {
        public class Request
        {
            /// <inheritdoc cref="User.Email"/>
            public string Email { get; set; }


            /// <summary>
            /// Пароль
            /// </summary>
            public string Password { get; set; }

        }

        public class Response
        {
            /// <summary>
            /// Токен
            /// </summary>
            public string Token { get; set; }

        }

    }
}
