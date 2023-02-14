using Announcements.Application.Identity.Interfaces;
using Announcements.Application.Implementations.Services.Announcements;
using Announcements.Application.Interfaces.Repositories;
using Announcements.Application.Interfaces.Services.Announcements.Contracts.Exceptions;
using Announcements.Application.Interfaces.Services.Files;
using Announcements.Application.Mappings;
using Announcements.Domain.Entities;
using Announcements.Infrastructure.DataAccess.Repositories;
using AutoFixture;
using AutoMapper;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Announcements.Tests
{
    public class AnnouncementServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAnnouncementRepository> _repository;
        private readonly Fixture _fixture;
        private readonly Mock<IIdentityService> _IdentityServise;
        private readonly Mock<IFileService> _FileServise;
        private readonly ICommentRepository _commentRepository;
        private readonly AnnouncementService _AnnouncementService;
        public AnnouncementServiceTests()
        {
            var config = new MapperConfiguration(mc => mc.AddProfile(new AnnouncementMappingProfile()));
            _mapper = config.CreateMapper();
            _repository = new Mock<IAnnouncementRepository>();
            _FileServise = new Mock<IFileService>();
            _IdentityServise = new Mock<IIdentityService>();
            _commentRepository = new Mock<ICommentRepository>().Object;
            _AnnouncementService = new AnnouncementService(_repository.Object, _mapper, _IdentityServise.Object, _commentRepository, _FileServise.Object);
            _fixture = new Fixture();
        }
        [Fact]
        public async Task CreateAnnouncement()
        {
            CancellationToken cancellationToken = new CancellationToken();
            Announcement announcement = new Announcement { ID = 7, Title = "111", Description = "Text" };
            _repository
                .Setup(_ => _.Add(announcement, cancellationToken));

            Assert.NotNull(_repository.Object.Add(announcement, cancellationToken));
        }
        [Fact]
        public async Task DeleteAnnouncement()
        {
            CancellationToken cancellationToken = new CancellationToken();
            Announcement announcement = new Announcement { ID = 7, Title = "111", Description = "Text" };
            _repository
                .Setup(_ => _.DeleteAnnouncement(announcement.ID, cancellationToken));

            bool cond = Equals(_repository.Object.DeleteAnnouncement(announcement.ID, cancellationToken), default);

            Assert.False(cond);
        }
        [Fact]
        public async Task GetAnnouncement()
        {
            CancellationToken cancellationToken = new CancellationToken();
            Announcement announcement = new Announcement { ID = 7, Title = "111", Description = "Text"};
            _repository
                .Setup(_ => _.FindById(announcement.ID, cancellationToken));

            Assert.NotNull(_repository.Object.FindById(announcement.ID, cancellationToken));
        }
        [Fact]
        public async Task EditAnnouncement()
        {
            CancellationToken cancellationToken = new CancellationToken();
            Announcement announcement = new Announcement { ID = 7, Title = "111", Description = "Text"};
            _repository
                .Setup(_ => _.Update(announcement, cancellationToken));

            Assert.NotEqual(default, _repository.Object.Update(announcement, cancellationToken));
        }
    }
}
