using Announcements.Application.Mappings;
using Announcements.Application.Implementations.Services.Users;
using Announcements.Application.Interfaces.Repositories;
using Announcements.Domain.Entities;
using AutoMapper;
using Moq;
using System;
using Xunit;
using Announcements.Application.Interfaces.Services.Files;
using Microsoft.AspNetCore.Http;
using Announcements.Application.Interfaces.Services.Users;
using System.Threading.Tasks;
using System.Collections.Generic;
using Announcements.Application.Identity.Interfaces;

namespace Announcements.Tests
{
    public class UserServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _repository;
        private readonly Mock<IFileService> _fileService;
        private readonly IIdentityService _identityService;
        private readonly UserService _userService;
        public UserServiceTests()
        {
            var config = new MapperConfiguration(mc => mc.AddProfile(new UserMappingProfile()));
            _mapper = config.CreateMapper();
            _repository = new Mock<IUserRepository>();
            _fileService = new Mock<IFileService>();
            _identityService = new Mock<IIdentityService>().Object;
            _userService = new UserService(_repository.Object,_mapper, _fileService.Object, _identityService);
        }
        [Fact]
        public async Task GetAllUsers()
        {
            //arrange
            List<User> users = new List<User> { new User { ID = "1", UserName="Name" } };

           // _repository
              //  .Setup(_ => _.GetPaged())
               // .Returns((System.Linq.IQueryable<User>)users)
              //  .Verifiable();
            //act
            //List<User> result = await _userService.Register();
            //assert

        }

    }
}
