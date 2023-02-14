using Announcements.Application.Interfaces.Repositories;
using Announcements.Application.Interfaces.Services.Users.Contracts.Exceptions;
using Announcements.Application.RequestModels;
using Announcements.Domain.Entities;
using Announcements.Domain.Helpers;
using Announcements.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Infrastructure.DataAccess.Repositories
{
    /// <summary>Репозиторий пользователей</summary>
    /// <inheritdoc cref="IUserRepository"/>
    public class UserRepository : Repository<User, string>, IUserRepository
    {
        UserManager<AppIdentityUser> _userManager;

        public UserRepository(AnnouncementDBContext DBContext, UserManager<AppIdentityUser> userManager) : base(DBContext)
        {
            _userManager = userManager;
        }


        ///<inheritdoc/>
        public async Task Delete(string id, CancellationToken cancellationToken)
        {
            var user = await base.FindById(id, cancellationToken);

            if (user == null)
            {
                throw new UserNotFoundException("User not found");
            }

            user.Status = UserStatus.Deleted;
            _DBContext.DomainUsers.Update(user);

            await Save(cancellationToken);
        }


        ///<inheritdoc/>
        public new async Task<User> FindById(string id, CancellationToken cancellationToken)
        {
            User user = await base.FindById(id, cancellationToken);

            if (user == null) return null;

            var identityUser = await _userManager.FindByIdAsync(user.ID);

            user.UserName = identityUser.UserName;
            user.PhoneNumber = identityUser.PhoneNumber;
            user.Email = identityUser.Email;
            user.Role = _userManager.GetRolesAsync(identityUser).Result.FirstOrDefault();

            return user;
        }


        ///<inheritdoc/>
        public async Task<PagedList<User>> GetPaged(GetPagedUsersRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(PagedList<User>.ToPagedList(FindAll().Where(u => u.Status != UserStatus.Deleted),
                request.PageNumber,
                request.PageSize));
        }


        ///<inheritdoc/>
        public new async Task Update(User user, CancellationToken cancellationToken)
        {
            await base.Update(user, cancellationToken);
            var identityUser = await _userManager.FindByIdAsync(user.ID);
            identityUser.Email = user.Email;
            identityUser.NormalizedEmail = user.Email.ToUpper();
            identityUser.UserName = user.UserName;
            identityUser.NormalizedUserName = user.UserName.ToUpper();
            identityUser.PhoneNumber = user.PhoneNumber;
            await _userManager.UpdateAsync(identityUser);
        }

    }

}
