using AutoMapper;
using FFinder.Core.DataTransferObjects.Follower;
using FFinder.Entity.Concrete;

namespace FFinder.MappingProfiles
{
    public class FollowerMappingProfile : Profile
    {
        public FollowerMappingProfile()
        {
            CreateMap<FollowerAddDto, Follower>();
            CreateMap<FollowerUpdateDto, Follower>();
            CreateMap<FollowerDetailDto, Follower>()

                .ForMember(dest =>
                    dest.User1.Email, opt =>
                    opt.MapFrom(src => src.User1Email))
                .ForMember(dest =>
                    dest.User1.Firstname, opt =>
                    opt.MapFrom(src => src.User1Firstname))
                .ForMember(dest =>
                    dest.User1.Lastname, opt =>
                    opt.MapFrom(src => src.User1Lastname))
                .ForMember(dest =>
                    dest.User1.UserName, opt =>
                    opt.MapFrom(src => src.User1UserName))
                .ForMember(dest =>
                    dest.User2.Email, opt =>
                    opt.MapFrom(src => src.User2Email))
                .ForMember(dest =>
                    dest.User2.Firstname, opt =>
                    opt.MapFrom(src => src.User2Firstname))
                .ForMember(dest =>
                    dest.User2.Lastname, opt =>
                    opt.MapFrom(src => src.User2Lastname))
                .ForMember(dest =>
                    dest.User2.UserName, opt =>
                    opt.MapFrom(src => src.User2UserName))
                .ReverseMap();
            CreateMap<FollowerListDto, Follower>()
                .ForMember(dest =>
                    dest.User1.Email, opt =>
                    opt.MapFrom(src => src.User1Email))
                .ForMember(dest =>
                    dest.User1.Firstname, opt =>
                    opt.MapFrom(src => src.User1Firstname))
                .ForMember(dest =>
                    dest.User1.Lastname, opt =>
                    opt.MapFrom(src => src.User1Lastname))
                .ForMember(dest =>
                    dest.User1.UserName, opt =>
                    opt.MapFrom(src => src.User1UserName))
                .ForMember(dest =>
                    dest.User2.Email, opt =>
                    opt.MapFrom(src => src.User2Email))
                .ForMember(dest =>
                    dest.User2.Firstname, opt =>
                    opt.MapFrom(src => src.User2Firstname))
                .ForMember(dest =>
                    dest.User2.Lastname, opt =>
                    opt.MapFrom(src => src.User2Lastname))
                .ForMember(dest =>
                    dest.User2.UserName, opt =>
                    opt.MapFrom(src => src.User2UserName))
                .ReverseMap();
        }
    }
}