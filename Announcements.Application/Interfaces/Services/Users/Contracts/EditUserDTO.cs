using Announcements.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Announcements.Application.Interfaces.Services.Users.Contracts
{

    /// <summary>
    /// Модель редактирования пользователя
    /// </summary>
    public static class EditUserDTO
    {
        public sealed class Request
        {

            ///<inheritdoc cref="User.UserName"/>
            public string UserName { get; set; }


            ///<inheritdoc cref="User.Email"/>
            public string Email { get; set; }


            ///<inheritdoc cref="User.PhoneNumber"/>
            public string PhoneNumber { get; set; }


            /// <summary>
            /// Новый аватар пользователя
            /// </summary>
            public IFormFile UserAvatar { get; set; }

        }


        public sealed class Response
        {
            ///<inheritdoc cref="BaseEntity.ID"/>
            public string ID { get; set; }

        }

    }
}
