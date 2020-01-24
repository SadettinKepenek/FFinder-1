using AutoMapper;
using FFinder.Core.DataTransferObjects.CommentRate;
using FFinder.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFinder.MappingProfiles
{
    public class CommentRateMappingProfile : Profile
    {
        public CommentRateMappingProfile()
        {
            CreateMap<CommentRateAddDto, CommentRate>().ReverseMap();
            CreateMap<CommentRate, CommentRateListDto>()
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
                    dest.OwnerProfilePhoto, opt =>
                    opt.MapFrom(src => src.Owner.ProfilePhotoUrl))
                .ForMember(dest =>
                    dest.CommentBody, opt =>
                    opt.MapFrom(src => src.Comment.CommentBody))
                .ForMember(dest =>
                    dest.CommentDate, opt =>
                    opt.MapFrom(src => src.Comment.CommentDate))
                .ForMember(dest =>
                    dest.CommentOwnerId, opt =>
                    opt.MapFrom(src => src.Comment.OwnerId))
                .ForMember(dest =>
                    dest.CommentPostId, opt =>
                    opt.MapFrom(src => src.Comment.PostId))

                .ReverseMap();
            CreateMap<CommentRate, CommentRateDetailDto>()
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
                    dest.CommentBody, opt =>
                    opt.MapFrom(src => src.Comment.CommentBody))
                .ForMember(dest =>
                    dest.CommentDate, opt =>
                    opt.MapFrom(src => src.Comment.CommentDate))
                .ForMember(dest =>
                    dest.CommentOwnerId, opt =>
                    opt.MapFrom(src => src.Comment.OwnerId))
                .ForMember(dest =>
                    dest.CommentPostId, opt =>
                    opt.MapFrom(src => src.Comment.PostId))
                .ForMember(dest =>
                    dest.OwnerProfilePhoto, opt =>
                    opt.MapFrom(src => src.Owner.ProfilePhotoUrl))
                .ReverseMap();
            CreateMap<CommentRateUpdateDto, CommentRate>().ReverseMap();
        }
    }
}
