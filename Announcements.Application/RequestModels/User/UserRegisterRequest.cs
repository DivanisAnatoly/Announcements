using Microsoft.AspNetCore.Http;

namespace Announcements.Application.RequestModels
{
    /// <summary>
    /// Модель запроса на регистрацию пользователя
    /// </summary>
    public sealed class UserRegisterRequest
    {
        ///<inheritdoc cref="Domain.Entities.User.UserName"/>
        public string UserName { get; set; }


        ///<inheritdoc cref="Domain.Entities.User.Email"/>
        public string Email { get; set; }


        ///<inheritdoc cref="Domain.Entities.User.PhoneNumber"/>
        public string PhoneNumber { get; set; }


        /////<inheritdoc cref="Domain.Entities.User.Password"/>
        public string Password { get; set; }


        /// <summary>
        /// Аватар пользователя
        /// </summary>
        public IFormFile UserAvatar { get; set; }

    }
}
