using Announcements.Domain.Entities;

namespace Announcements.Application.Identity.Contracts
{
    public static class CreateIdentityUserDTO
    {
        public class Request
        {
            ///<inheritdoc cref="User.UserName"/>
            public string UserName { get; set; }


            ///<inheritdoc cref="User.Email"/>
            public string Email { get; set; }


            ///<inheritdoc cref="User.PhoneNumber"/>
            public string PhoneNumber { get; set; }


            /// <summary>
            /// Пароль
            /// </summary>
            public string Password { get; set; }

        }

        public class Response
        {
            ///<inheritdoc cref="BaseEntity.ID"/>
            public string ID { get; set; }


            /// <summary>
            /// Статус ответа
            /// </summary>
            public bool IsSuccess { get; set; }

        }

    }
}
