using Announcements.Application.Implementations.Services.Comments;
using Announcements.Application.Interfaces.Repositories;
using Announcements.Application.Interfaces.Services.Comments.Contracts.Exceptions;
using Announcements.Application.Interfaces.Services.Comments.Contracts;
using Announcements.Application.Mappings;
using Announcements.Domain.Entities;
using AutoFixture;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Announcements.Application.Interfaces.Services.Files;
using Announcements.Application.Identity.Interfaces;

namespace Announcements.Tests
{
    public class CommentServiceTests
    {
        private readonly Mock<IIdentityService> _IdentityServise;
        private readonly Mock<IFileService> _FileServise;
        private readonly IMapper _mapper;
        private readonly Mock<ICommentRepository> _repository;
        private readonly CommentService _CommentService;
        private readonly Fixture _fixture;
        
        public CommentServiceTests()
        {
            var config = new MapperConfiguration(mc => mc.AddProfile(new CommentMappingProfile()));
            _mapper = config.CreateMapper();
            _repository = new Mock<ICommentRepository>();
            _FileServise = new Mock<IFileService>();
            _IdentityServise = new Mock<IIdentityService>();
            _CommentService = new CommentService(_repository.Object, _mapper, _IdentityServise.Object, _FileServise.Object);
            _fixture = new Fixture();
        }
        [Fact]
        public async Task GetByID()
        {
            CancellationToken cancellationToken = new CancellationToken();
            //arrange
            Comment comment = new Comment { ID = 1, Text= "Name" };
           
            _repository
              .Setup(_ => _.FindById(comment.ID, cancellationToken ))
              .ReturnsAsync(comment)
              .Verifiable();
            //act
            GetCommentDTO.Response result = await _CommentService.GetComment(1, cancellationToken);
            //assert
            _repository.Verify();
            Assert.NotNull(result);
           
        }
        [Fact]
        public async Task GetCommentbyId_Throws_Exception_if_comment_Deleted()
        {
            CancellationToken cancellationToken = new CancellationToken();
            Comment comment = new Comment { ID = 1, Text = "Name", Status= CommentStatus.Deleted };
            _repository
                 .Setup(_ => _.FindById(comment.ID, cancellationToken))
              .ReturnsAsync(comment)
              .Verifiable();
           
            await Assert.ThrowsAsync<CommentNotFoundException>(async ()=> await _CommentService.GetComment(1, cancellationToken)); 
        }
        [Fact]
        public async Task Deleting_Comment()
        {
            CancellationToken cancellationToken = new CancellationToken();
            Comment comment = new Comment { ID = 1, Text = "Name", Status = CommentStatus.Deleted };
            //arrange
            _repository
            .Setup(_ => _.DeleteComment(comment.ID, cancellationToken));
            //act
            await _CommentService.DeleteComment(comment.ID, cancellationToken);
            //assert
            bool cond = Equals(_repository.Object.DeleteComment(comment.ID, cancellationToken).Status, default);

            _repository.Verify();
            Assert.False(cond);
        }
        [Fact]
        public async Task CreateComment()
        {
           CancellationToken cancellationToken = new CancellationToken();
           Comment comment = new Comment { ID = 8, Text = "Name" };
            _repository
            .Setup(_ => _.Add(comment, cancellationToken));
            
            
            _repository.Verify();
            Assert.NotNull(comment);
         }
        [Fact]
        public async Task EditComment()
        {
            CancellationToken cancellationToken = new CancellationToken();
            Comment comment = new Comment { ID = 7, Text = "Name" };
            _repository
                .Setup(_ => _.Update(comment, cancellationToken));
                
           
           _repository.Verify();
            Assert.NotNull(comment);
        }
    }
}
