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
            CreateMap<CommentRateListDto, CommentRate>()
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
                    dest.Comment.CommentBody, opt =>
                    opt.MapFrom(src => src.CommentBody))
                .ForMember(dest =>
                    dest.Comment.CommentDate, opt =>
                    opt.MapFrom(src => src.CommentDate))
                .ForMember(dest =>
                    dest.Comment.OwnerId, opt =>
                    opt.MapFrom(src => src.CommentOwnerId))
                .ForMember(dest =>
                    dest.Comment.PostId, opt =>
                    opt.MapFrom(src => src.CommentPostId))

                .ReverseMap();
            CreateMap<CommentRateDetailDto, CommentRate>()
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
                    dest.Comment.CommentBody, opt =>
                    opt.MapFrom(src => src.CommentBody))
                .ForMember(dest =>
                    dest.Comment.CommentDate, opt =>
                    opt.MapFrom(src => src.CommentDate))
                .ForMember(dest =>
                    dest.Comment.OwnerId, opt =>
                    opt.MapFrom(src => src.CommentOwnerId))
                .ForMember(dest =>
                    dest.Comment.PostId, opt =>
                    opt.MapFrom(src => src.CommentPostId))
                .ReverseMap();
            CreateMap<CommentRateUpdateDto, CommentRate>().ReverseMap();
        }
    }
}
