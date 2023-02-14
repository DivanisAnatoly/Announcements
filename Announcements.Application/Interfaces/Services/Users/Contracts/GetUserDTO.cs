using Announcements.Domain.Entities;
using System;

namespace Announcements.Application.Interfaces.Services.Users.Contracts
{
    /// <summary>
    /// Модель получения пользователя
    /// </summary>
    public static class GetUserDTO
    {
        public sealed class Response
        {

            ///<inheritdoc cref="BaseEntity.ID"/>
            public string ID { get; set; }


            ///<inheritdoc cref="User.UserName"/>
            public string UserName { get; set; }


            ///<inheritdoc cref="User.Email"/>
            public string Email { get; set; }


            ///<inheritdoc cref="User.PhoneNumber"/>
            public string PhoneNumber { get; set; }


            ///<inheritdoc cref="User.Role"/>
            public string Role { get; set; }


            /// <summary>
            /// Аватар пользователя
            /// </summary>
            public Uri UserAvatarUri { get; set; }

        }

    }
}
