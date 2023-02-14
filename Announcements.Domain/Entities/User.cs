using Announcements.Domain.Entities.Shared;
using System.Collections.Generic;

namespace Announcements.Domain.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public sealed class User : MutableEntity<string>
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// Эл. почта пользователя
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// Телефон пользователя
        /// </summary>
        public string PhoneNumber { get; set; }


        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string Role { get; set; }


        /// <inheritdoc cref="UserStatus"/>
        public UserStatus Status { get; set; }


        /// <summary>
        /// Комнентарии пользователя
        /// </summary>
        public ICollection<Comment> Comments { get; set; }


        /// <summary>
        /// Объявления пользователя
        /// </summary>
        public ICollection<Announcement> Announcements { get; set; }


        /// <summary>
        /// Файлы прикрепленные к пользователю
        /// </summary>
        public ICollection<UserFile> UserFiles { get; set; }

    }
}
