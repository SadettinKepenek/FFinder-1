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
            CreateMap<Post, PostListDto>()
                .ForMember(c=> c.OwnerUserName,d=> d.MapFrom(e => e.Owner.UserName))               
                .ForMember(c=> c.OwnerFirstname,d=> d.MapFrom(e => e.Owner.Firstname))
                .ForMember(c=> c.OwnerLastname,d=> d.MapFrom(e => e.Owner.Lastname))
                .ForMember(c=> c.OwnerEmail,d=> d.MapFrom(e => e.Owner.Email))
                .ReverseMap();
            CreateMap<Post, PostDetailDto>()
                .ForMember(c => c.OwnerUserName, d => d.MapFrom(e => e.Owner.UserName))
                .ForMember(c => c.OwnerFirstname, d => d.MapFrom(e => e.Owner.Firstname))
                .ForMember(c => c.OwnerLastname, d => d.MapFrom(e => e.Owner.Lastname))
                .ForMember(c => c.OwnerEmail, d => d.MapFrom(e => e.Owner.Email))
               .ReverseMap();
        }
    }
}