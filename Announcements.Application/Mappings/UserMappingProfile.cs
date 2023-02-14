using Announcements.Application.Identity.Contracts;
using Announcements.Application.Interfaces.Services.Users.Contracts;
using Announcements.Domain.Entities;
using AutoMapper;

namespace Announcements.Application.Mappings
{
    /// <summary>
    /// Мапер пользователей на уровне Application 
    /// </summary>
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, GetUserDTO.Response>();
            CreateMap<RegisterUserDTO.Request, CreateIdentityUserDTO.Request>();
            CreateMap<CreateIdentityUserDTO.Request, User>();
            CreateMap<User, UserPageItem>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        }
    }
}
