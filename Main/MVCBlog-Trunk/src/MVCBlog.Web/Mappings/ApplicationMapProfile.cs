namespace MVCBlog.Web.Mappings
{
    using AutoMapper;
    using MVCBlog.Web.Models;
    using MVCBlog.Domain.Entities;

    public class ApplicationMapProfile : Profile
    {
        public ApplicationMapProfile()
        {
            CreateMap<Post, PostDto>();

            CreateMap<Post, PostOverviewDto>()
                .ForMember(dest => dest.CommentsCount, opt => opt.ResolveUsing(src => src.Comments.Count));

            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.PostId, opt => opt.ResolveUsing(src => src.Post.Id))
                .ReverseMap()
                .ForMember(dest => dest.Post, opt => opt.Ignore())
                .ForMember(dest => dest.DatePublished, opt => opt.Ignore());
        }
    }
}
