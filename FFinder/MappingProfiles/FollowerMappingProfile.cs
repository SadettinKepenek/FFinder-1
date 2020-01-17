using AutoMapper;
using FFinder.Core.DataTransferObjects.Follower;
using FFinder.Entity.Concrete;

namespace FFinder.MappingProfiles
{
    public class FollowerMappingProfile:Profile
    {
        public FollowerMappingProfile()
        {
            CreateMap<FollowerAddDto, Follower>();
            CreateMap<FollowerUpdateDto, Follower>();
            CreateMap<FollowerDetailDto, Follower>().ReverseMap();
            CreateMap<FollowerListDto, Follower>().ReverseMap();
        }
    }
}