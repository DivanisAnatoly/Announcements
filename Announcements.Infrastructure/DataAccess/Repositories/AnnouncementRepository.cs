using Announcements.Application.Interfaces.Repositories;
using Announcements.Application.Interfaces.Services.Announcements.Contracts.Exceptions;
using Announcements.Application.RequestModels.Announcement;
using Announcements.Domain.Entities;
using Announcements.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Infrastructure.DataAccess.Repositories
{
    /// <summary>Репозиторий пользователей</summary>
    /// <inheritdoc cref="IAnnouncementRepository"/>
    public class AnnouncementRepository : Repository<Announcement, int>, IAnnouncementRepository
    {
        private readonly IUserRepository _userRepository;


        /// <summary>
        /// Конструктор
        /// </summary>
        public AnnouncementRepository(AnnouncementDBContext DBContext, IUserRepository userRepository) : base(DBContext)
        {
            _userRepository = userRepository;
        }


        /// <inheritdoc/>
        public new async Task<Announcement> FindById(int announcementID, CancellationToken cancellationToken)
        {
            Announcement announcement = await _DBContext.Set<Announcement>()
                .Include(a => a.Category)
                .Include(a => a.Region)
                .FirstOrDefaultAsync(a => a.ID == announcementID);
            announcement.Owner = await _userRepository.FindById(announcement.OwnerID, cancellationToken);
            return announcement;
        }


        /// <inheritdoc/>
        public async Task<IEnumerable<Announcement>> GetAllAnnouncemets(CancellationToken cancellationToken)
        {
            return await FindAll().Where(a => a.Status == AnnouncementStatus.Normal).ToListAsync(cancellationToken);
        }


        /// <inheritdoc/>
        public async Task<bool> DeleteAnnouncement(int id, CancellationToken cancellationToken)
        {
            var announcement = await FindById(id, cancellationToken);

            if (announcement == null || announcement.Status != AnnouncementStatus.Normal)
            {
                throw new AnnouncementNotFoundException("Announcement not found");
            }

            announcement.Status = AnnouncementStatus.Deleted;
            _DBContext.Announcements.Update(announcement);
            await Save(cancellationToken);

            return announcement.Status == AnnouncementStatus.Deleted;
        }


        /// <inheritdoc/>
        public async Task<PagedList<Announcement>> GetPaged(GetPagedAnnouncementsRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(PagedList<Announcement>.ToPagedList(FindAll().Where(a => a.Status != AnnouncementStatus.Deleted),
                request.PageNumber,
                request.PageSize));
        }

    }
}
