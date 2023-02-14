using Announcements.Application.Interfaces.Services.Announcements.Contracts;
using Announcements.Application.RequestModels;
using AutoMapper;

namespace Announcements.API.Mappings
{
    /// <summary>
    /// Мапер объявлений на уровне API 
    /// </summary>
    public class AnnouncementMappingProfile : Profile
    {
        public AnnouncementMappingProfile()
        {
            CreateMap<AnnouncementCreateRequest, CreateAnnouncementDTO.Request>();
            CreateMap<AnnouncementEditRequest, EditAnnouncementDTO.Request>();
        }
    }
}
