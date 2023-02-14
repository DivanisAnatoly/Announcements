using Announcements.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Announcements.Application.Interfaces.Services.Users.Contracts
{
    /// <summary>
    /// Модель регистрации пользователя
    /// </summary>
    public static class RegisterUserDTO
    {
        public sealed class Request
        {
            ///<inheritdoc cref="User.UserName"/>
            public string UserName { get; set; }


            ///<inheritdoc cref="User.Email"/>
            public string Email { get; set; }


            ///<inheritdoc cref="User.PhoneNumber"/>
            public string PhoneNumber { get; set; }


            ///<inheritdoc cref="User.Password"/>
            public string Password { get; set; }


            /// <summary>
            /// Аватар пользователя
            /// </summary>
            public IFormFile UserAvatar { get; set; }

        }


        public class Response
        {
            ///<inheritdoc cref="BaseEntity.ID"/>
            public string ID { get; set; }


            ///<inheritdoc cref="User.UserName"/>
            public string UserName { get; set; }

        }

    }
}
