using AutoMapper;
using FFinder.Core.DataTransferObjects.Post;
using FFinder.Entity.Concrete;

namespace FFinder.MappingProfiles
{
    public class PostMappingProfile:Profile
    {
        public PostMappingProfile()
        {
            CreateMap<PostAddDto, Post>();
            CreateMap<PostUpdateDto, Post>();
            CreateMap<PostListDto, Post>().ReverseMap();
            CreateMap<PostDetailDto, Post>().ReverseMap();
        }
    }
}