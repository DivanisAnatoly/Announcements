using Announcements.Application.Interfaces.Services.Announcements.Contracts;
using Announcements.Domain.Entities;
using AutoMapper;

namespace Announcements.Application.Mappings
{
    /// <summary>
    /// Мапер объявлений на уровне Application 
    /// </summary>
    public class AnnouncementMappingProfile : Profile
    {
        public AnnouncementMappingProfile()
        {
            CreateMap<CreateAnnouncementDTO.Request, Announcement>();
            CreateMap<EditAnnouncementDTO.Request, Announcement>();
            CreateMap<Announcement, GetAnnouncementDTO.Response>()
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.UserName));
            CreateMap<Announcement, AnnouncementPageItem>()
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
