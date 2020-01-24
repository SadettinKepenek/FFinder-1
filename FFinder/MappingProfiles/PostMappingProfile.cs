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
            CreateMap<PostListDto, Post>()
                .ForMember(c=> c.Owner.UserName,d=> d.MapFrom(e => e.Owner.UserName))               
                .ForMember(c=> c.Owner.Id,d=> d.MapFrom(e => e.Owner.Id))
                .ForMember(c=> c.Owner.ProfilePhotoUrl,d=> d.MapFrom(e => e.Owner.ProfilePhotoUrl))
                .ReverseMap();
            CreateMap<PostDetailDto, Post>()
               .ForMember(c => c.Owner.UserName, d => d.MapFrom(e => e.Owner.UserName))
               .ForMember(c => c.Owner.Id, d => d.MapFrom(e => e.Owner.Id))
               .ForMember(c => c.Owner.ProfilePhotoUrl, d => d.MapFrom(e => e.Owner.ProfilePhotoUrl))
               .ReverseMap();
        }
    }
}