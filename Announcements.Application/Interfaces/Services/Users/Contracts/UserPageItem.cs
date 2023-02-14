using Announcements.Application.Common;
using Announcements.Domain.Entities;

namespace Announcements.Application.Interfaces.Services.Users.Contracts
{

    /// <summary>
    /// Модель элемента в постраничном списке пользователей
    /// </summary>
    public class UserPageItem
    {

        ///<inheritdoc cref="BaseEntity.ID"/>
        public string ID { get; set; }


        ///<inheritdoc cref="User.UserName"/>
        public string UserName { get; set; }


        ///<inheritdoc cref="User.Status"/>
        public string Status { get; set; }


        ///<inheritdoc cref="RoleConstants"/>
        public string Role { get; set; }
    }

}
