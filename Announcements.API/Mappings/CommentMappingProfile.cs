using Announcements.Application.Interfaces.Services.Comments.Contracts;
using Announcements.Application.RequestModels;
using AutoMapper;

namespace Announcements.API.Mappings
{
    /// <summary>
    /// Мапер комментариев на уровне API 
    /// </summary>
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<CommentCreateRequest, CreateCommentDTO.Request>();
            CreateMap<CommentEditRequest, EditCommentDTO.Request>();
        }
    }
}
