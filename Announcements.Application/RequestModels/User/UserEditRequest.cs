using Microsoft.AspNetCore.Http;

namespace Announcements.Application.RequestModels
{
    /// <summary>
    /// Модель запроса на редактирование данных пользователя
    /// </summary>
    public sealed class UserEditRequest
    {

        ///<inheritdoc cref="Domain.Entities.User.UserName"/>
        public string UserName { get; set; }


        ///<inheritdoc cref="Domain.Entities.User.Email"/>
        public string Email { get; set; }


        ///<inheritdoc cref="Domain.Entities.User.PhoneNumber"/>
        public string PhoneNumber { get; set; }


        /// <summary>
        /// Новый аватар пользователя
        /// </summary>
        public IFormFile UserAvatar { get; set; }

    }
}
