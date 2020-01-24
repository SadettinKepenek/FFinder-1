using AutoMapper;
using FFinder.Core.DataTransferObjects.PostRate;
using FFinder.Entity.Concrete;

namespace FFinder.MappingProfiles
{
    public class PostRateMappingProfile:Profile
    {
        public PostRateMappingProfile()
        {
            CreateMap<PostRateAddDto, PostRate>();
            CreateMap<PostRateUpdateDto, PostRate>();
            CreateMap<PostRate, PostRateListDto>()
                .ForMember(dest =>
                    dest.OwnerUserName, opt =>
                    opt.MapFrom(src => src.Owner.UserName))
                .ForMember(dest =>
                    dest.OwnerId, opt =>
                    opt.MapFrom(src => src.Owner.Id))
                .ForMember(dest =>
                    dest.OwnerEmail, opt =>
                    opt.MapFrom(src => src.Owner.Email))
                .ForMember(dest =>
                    dest.OwnerFirstname, opt =>
                    opt.MapFrom(src => src.Owner.Firstname))
                .ForMember(dest =>
                    dest.OwnerLastname, opt =>
                    opt.MapFrom(src => src.Owner.Lastname))
         
                .ForMember(dest =>
                    dest.PostBody, opt =>
                    opt.MapFrom(src => src.Post.PostBody))
                .ForMember(dest =>
                    dest.PostImageUrl, opt =>
                    opt.MapFrom(src => src.Post.PostImageUrl))
                .ForMember(dest =>
                    dest.IsActive, opt =>
                    opt.MapFrom(src => src.Post.IsActive))
                .ForMember(dest =>
                    dest.OwnerId, opt =>
                    opt.MapFrom(src => src.Post.OwnerId))
                .ForMember(dest =>
                    dest.PostPublishDate, opt =>
                    opt.MapFrom(src => src.Post.PublishDate))
                .ForMember(dest =>
                    dest.PostOwnerProfilePhoto, opt =>
                    opt.MapFrom(src => src.Post.Owner.ProfilePhotoUrl))
                .ForMember(dest =>
                    dest.OwnerProfilePhoto, opt =>
                    opt.MapFrom(src => src.Owner.ProfilePhotoUrl))
                .ReverseMap();
            CreateMap<PostRate, PostRateDetailDto>()
                 .ForMember(dest =>
                    dest.OwnerUserName, opt =>
                    opt.MapFrom(src => src.Owner.UserName))
                .ForMember(dest =>
                    dest.OwnerId, opt =>
                    opt.MapFrom(src => src.Owner.Id))
                .ForMember(dest =>
                    dest.OwnerEmail, opt =>
                    opt.MapFrom(src => src.Owner.Email))
                .ForMember(dest =>
                    dest.OwnerFirstname, opt =>
                    opt.MapFrom(src => src.Owner.Firstname))
                .ForMember(dest =>
                    dest.OwnerLastname, opt =>
                    opt.MapFrom(src => src.Owner.Lastname))
                .ForMember(dest =>
                    dest.PostBody, opt =>
                    opt.MapFrom(src => src.Post.PostBody))
                .ForMember(dest =>
                    dest.PostImageUrl, opt =>
                    opt.MapFrom(src => src.Post.PostImageUrl))
                .ForMember(dest =>
                    dest.IsActive, opt =>
                    opt.MapFrom(src => src.Post.IsActive))
                .ForMember(dest =>
                    dest.OwnerId, opt =>
                    opt.MapFrom(src => src.Post.OwnerId))
                .ForMember(dest =>
                    dest.PostPublishDate, opt =>
                    opt.MapFrom(src => src.Post.PublishDate))
                 .ForMember(dest =>
                     dest.PostOwnerProfilePhoto, opt =>
                     opt.MapFrom(src => src.Post.Owner.ProfilePhotoUrl))
                 .ForMember(dest =>
                     dest.OwnerProfilePhoto, opt =>
                     opt.MapFrom(src => src.Owner.ProfilePhotoUrl))
                 .ReverseMap();
        }
    }
}