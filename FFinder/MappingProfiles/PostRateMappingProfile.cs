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
            CreateMap<PostRateListDto, PostRate>()
                .ForMember(dest =>
                    dest.Owner.UserName, opt =>
                    opt.MapFrom(src => src.OwnerUserName))
                .ForMember(dest =>
                    dest.Owner.Id, opt =>
                    opt.MapFrom(src => src.OwnerId))
                .ForMember(dest =>
                    dest.Owner.Email, opt =>
                    opt.MapFrom(src => src.OwnerEmail))
                .ForMember(dest =>
                    dest.Owner.Firstname, opt =>
                    opt.MapFrom(src => src.OwnerFirstname))
                .ForMember(dest =>
                    dest.Owner.Lastname, opt =>
                    opt.MapFrom(src => src.OwnerLastname))
                .ForMember(dest =>
                    dest.Post.PostBody, opt =>
                    opt.MapFrom(src => src.PostBody))
                .ForMember(dest =>
                    dest.Post.PostImageUrl, opt =>
                    opt.MapFrom(src => src.PostImageUrl))
                .ForMember(dest =>
                    dest.Post.IsActive, opt =>
                    opt.MapFrom(src => src.PostIsActive))
                .ForMember(dest =>
                    dest.Post.OwnerId, opt =>
                    opt.MapFrom(src => src.PostOwnerId))
                .ForMember(dest =>
                    dest.Post.PublishDate, opt =>
                    opt.MapFrom(src => src.PostPublishDate))

                .ReverseMap();
            CreateMap<PostRateDetailDto, PostRate>()
                .ForMember(dest =>
                    dest.Owner.UserName, opt =>
                    opt.MapFrom(src => src.OwnerUserName))
                .ForMember(dest =>
                    dest.Owner.Id, opt =>
                    opt.MapFrom(src => src.OwnerId))
                .ForMember(dest =>
                    dest.Owner.Email, opt =>
                    opt.MapFrom(src => src.OwnerEmail))
                .ForMember(dest =>
                    dest.Owner.Firstname, opt =>
                    opt.MapFrom(src => src.OwnerFirstname))
                .ForMember(dest =>
                    dest.Owner.Lastname, opt =>
                    opt.MapFrom(src => src.OwnerLastname))
                .ForMember(dest =>
                    dest.Post.PostBody, opt =>
                    opt.MapFrom(src => src.PostBody))
                .ForMember(dest =>
                    dest.Post.PostImageUrl, opt =>
                    opt.MapFrom(src => src.PostImageUrl))
                .ForMember(dest =>
                    dest.Post.IsActive, opt =>
                    opt.MapFrom(src => src.PostIsActive))
                .ForMember(dest =>
                    dest.Post.OwnerId, opt =>
                    opt.MapFrom(src => src.PostOwnerId))
                .ForMember(dest =>
                    dest.Post.PublishDate, opt =>
                    opt.MapFrom(src => src.PostPublishDate))
                .ReverseMap();
        }
    }
}