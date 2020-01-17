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
            CreateMap<PostRateListDto, PostRate>().ReverseMap();
            CreateMap<PostRateDetailDto, PostRate>().ReverseMap();
        }
    }
}