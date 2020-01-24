using AutoMapper;
using FFinder.Core.DataTransferObjects.Comment;
using FFinder.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFinder.MappingProfiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<CommentAddDto, Comment>().ReverseMap();


            CreateMap<Comment, CommentListDto>()
                .ForMember(dest => 
                    dest.OwnerUserName, opt => 
                    opt.MapFrom(src => src.Owner.UserName))
                .ForMember(dest =>
                    dest.OwnerId, opt =>
                    opt.MapFrom(src => src.OwnerId))
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
                    dest.OwnerProfilePhoto, opt =>
                    opt.MapFrom(src => src.Owner.ProfilePhotoUrl))
                .ReverseMap();
            CreateMap<Comment, CommentDetailDto>()
                .ForMember(dest =>
                    dest.OwnerUserName, opt =>
                    opt.MapFrom(src => src.Owner.UserName))
                .ForMember(dest =>
                    dest.OwnerId, opt =>
                    opt.MapFrom(src => src.OwnerId))
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
                    dest.OwnerProfilePhoto, opt =>
                    opt.MapFrom(src => src.Owner.ProfilePhotoUrl))
                .ReverseMap();
            CreateMap<CommentUpdateDto, Comment>().ReverseMap();
        }
    }
}
