using Announcements.Application.Interfaces.Repositories;
using Announcements.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Infrastructure.DataAccess.Repositories
{

    /// <summary>Репозиторий файлов</summary>
    /// <inheritdoc cref="IAnnouncementFileRepository"/>
    public class AnnouncementFileRepository : Repository<AnnouncementFile, int>, IAnnouncementFileRepository
    {
        public AnnouncementFileRepository(AnnouncementDBContext DBContext) : base(DBContext)
        {

        }


        /// <inheritdoc/>
        public async Task DeleteAnnouncementImages(int announcementId, CancellationToken cancellationToken)
        {
            var files = FindAll().Where(af => af.AnnouncementID == announcementId && af.Status != FileStatus.Deleted).ToList();

            if (files == null) return;

            files.ForEach(f => f.Status = FileStatus.Deleted);

            await Save(cancellationToken);
        }


        /// <inheritdoc/>
        public async Task<IEnumerable<AnnouncementFile>> FindImagesByAnnouncementId(int announcementId, CancellationToken cancellationToken)
        {
            return await FindAll().Where(af => af.AnnouncementID == announcementId && af.Status != FileStatus.Deleted).ToListAsync(cancellationToken);
        }


        /// <inheritdoc/>
        public async Task<AnnouncementFile> FindAnnouncementFaceImage(int announcementId, CancellationToken cancellationToken)
        {
            return await FindAll().FirstOrDefaultAsync(af => af.AnnouncementID == announcementId && af.Status != FileStatus.Deleted, cancellationToken);
        }


        /// <inheritdoc/>
        public async Task DeleteAnnouncementImage(int announcementId, string announcementFileName, CancellationToken cancellationToken)
        {
            var files = FindAll().FirstOrDefault(af => af.AnnouncementID == announcementId && af.Name == announcementFileName && af.Status != FileStatus.Deleted);

            if (files == null) return;

            files.Status = FileStatus.Deleted;

            await Save(cancellationToken);
        }

    }

}
