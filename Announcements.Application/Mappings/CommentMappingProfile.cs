using Announcements.Application.Interfaces.Services.Comments.Contracts;
using Announcements.Domain.Entities;
using AutoMapper;

namespace Announcements.Application.Mappings
{

    /// <summary>
    /// Мапер комментариев на уровне Application 
    /// </summary>
    public class CommentMappingProfile : Profile
    {

        public CommentMappingProfile()
        {


            CreateMap<CreateCommentDTO.Request, Comment>();
            CreateMap<EditCommentDTO.Request, Comment>();
            CreateMap<Comment, GetCommentDTO.Response>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.UserName));
            CreateMap<Comment, CommentPageItem>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.UserName));
        }
    }
}
