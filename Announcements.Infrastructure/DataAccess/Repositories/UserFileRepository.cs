using Announcements.Application.Interfaces.Repositories;
using Announcements.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Infrastructure.DataAccess.Repositories
{
    /// <summary>Репозиторий файлов</summary>
    /// <inheritdoc cref="IUserFileRepository"/>
    public class UserFileRepository : Repository<UserFile, int>, IUserFileRepository
    {
        public UserFileRepository(AnnouncementDBContext DBContext) : base(DBContext)
        {

        }


        /// <inheritdoc/>
        public async Task DeleteUserAvatar(string userId, CancellationToken cancellationToken)
        {
            var file = FindAll().FirstOrDefault(uf => uf.UserID == userId && uf.Status != FileStatus.Deleted);

            if (file == null) return;

            file.Status = FileStatus.Deleted;

            await Save(cancellationToken);
        }


        /// <inheritdoc/>
        public async Task<UserFile> FindAvatarByUserId(string userId, CancellationToken cancellationToken)
        {
            return await FindAll().FirstOrDefaultAsync(e => e.UserID == userId && e.Status != FileStatus.Deleted, cancellationToken);
        }

    }
}
