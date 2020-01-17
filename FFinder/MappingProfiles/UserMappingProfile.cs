using AutoMapper;
using FFinder.Core.DataTransferObjects.User;
using FFinder.Entity.Concrete;

namespace FFinder.MappingProfiles
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserAddDto, AuthIdentityUser>().ReverseMap();
            CreateMap<UserLoginRequestDto, AuthIdentityUser>().ReverseMap();
            CreateMap<UserUpdateDto, AuthIdentityUser>().ReverseMap();
            CreateMap<UserDetailDto, AuthIdentityUser>().ReverseMap();
            CreateMap<UserListDto, AuthIdentityUser>().ReverseMap();
        }
    }
}