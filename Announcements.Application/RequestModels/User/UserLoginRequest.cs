namespace Announcements.Application.RequestModels
{
    public class UserLoginRequest
    {
        ///<inheritdoc cref="Domain.Entities.User.Email"/>
        public string Email { get; set; }


        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

    }
}
