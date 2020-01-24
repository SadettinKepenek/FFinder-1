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
            CreateMap<Follower, FollowerDetailDto>()

                .ForMember(dest =>
                    dest.User1Email, opt =>
                    opt.MapFrom(src => src.User1.Email))
                .ForMember(dest =>
                    dest.User1Firstname, opt =>
                    opt.MapFrom(src => src.User1.Firstname))
                .ForMember(dest =>
                    dest.User1Lastname, opt =>
                    opt.MapFrom(src => src.User1.Lastname))
                .ForMember(dest =>
                    dest.User1UserName, opt =>
                    opt.MapFrom(src => src.User1.UserName))
                .ForMember(dest =>
                    dest.User2Email, opt =>
                    opt.MapFrom(src => src.User2.Email))
                .ForMember(dest =>
                    dest.User2Firstname, opt =>
                    opt.MapFrom(src => src.User2.Firstname))
                .ForMember(dest =>
                    dest.User2Lastname, opt =>
                    opt.MapFrom(src => src.User2.Lastname))
                .ForMember(dest =>
                    dest.User2UserName, opt =>
                    opt.MapFrom(src => src.User2.UserName))
                .ReverseMap();
            CreateMap<Follower, FollowerListDto>()
                .ForMember(dest =>
                    dest.User1Email, opt =>
                    opt.MapFrom(src => src.User1.Email))
                .ForMember(dest =>
                    dest.User1Firstname, opt =>
                    opt.MapFrom(src => src.User1.Firstname))
                .ForMember(dest =>
                    dest.User1Lastname, opt =>
                    opt.MapFrom(src => src.User1.Lastname))
                .ForMember(dest =>
                    dest.User1UserName, opt =>
                    opt.MapFrom(src => src.User1.UserName))
                .ForMember(dest =>
                    dest.User2Email, opt =>
                    opt.MapFrom(src => src.User2.Email))
                .ForMember(dest =>
                    dest.User2Firstname, opt =>
                    opt.MapFrom(src => src.User2.Firstname))
                .ForMember(dest =>
                    dest.User2Lastname, opt =>
                    opt.MapFrom(src => src.User2.Lastname))
                .ForMember(dest =>
                    dest.User2UserName, opt =>
                    opt.MapFrom(src => src.User2.UserName))
                .ReverseMap();
        }
    }
}