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
                .ForPath(dest => 
                    dest.OwnerUserName, opt => 
                    opt.MapFrom(src => src.Owner.UserName))
                .ForPath(dest =>
                    dest.OwnerId, opt =>
                    opt.MapFrom(src => src.OwnerId))
                .ForPath(dest =>
                    dest.OwnerEmail, opt =>
                    opt.MapFrom(src => src.Owner.Email))
                .ForPath(dest =>
                    dest.OwnerFirstname, opt =>
                    opt.MapFrom(src => src.Owner.Firstname))
                .ForPath(dest =>
                    dest.OwnerLastname, opt =>
                    opt.MapFrom(src => src.Owner.Lastname))
                .ReverseMap();
            CreateMap<Comment, CommentDetailDto>()
                .ForPath(dest =>
                    dest.OwnerUserName, opt =>
                    opt.MapFrom(src => src.Owner.UserName))
                .ForPath(dest =>
                    dest.OwnerId, opt =>
                    opt.MapFrom(src => src.OwnerId))
                .ForPath(dest =>
                    dest.OwnerEmail, opt =>
                    opt.MapFrom(src => src.Owner.Email))
                .ForPath(dest =>
                    dest.OwnerFirstname, opt =>
                    opt.MapFrom(src => src.Owner.Firstname))
                .ForPath(dest =>
                    dest.OwnerLastname, opt =>
                    opt.MapFrom(src => src.Owner.Lastname))
                .ReverseMap();
            CreateMap<CommentUpdateDto, Comment>().ReverseMap();
        }
    }
}
