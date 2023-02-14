using Announcements.Application.Identity.Contracts;
using Announcements.Application.Interfaces.Services.Users.Contracts;
using Announcements.Application.RequestModels;
using AutoMapper;

namespace Announcements.API.Mappings
{
    /// <summary>
    /// Мапер пользователей на уровне API 
    /// </summary>
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRegisterRequest, RegisterUserDTO.Request>();
            CreateMap<UserLoginRequest, LoginIdentityUserDTO.Request>();
            CreateMap<UserEditRequest, EditUserDTO.Request>();
        }
    }
}
