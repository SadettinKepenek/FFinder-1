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


            CreateMap<CommentListDto, Comment>()
                .ForPath(dest => 
                    dest.Owner.UserName, opt => 
                    opt.MapFrom(src => src.OwnerUserName))
                .ForPath(dest =>
                    dest.Owner.Id, opt =>
                    opt.MapFrom(src => src.OwnerId))
                .ForPath(dest =>
                    dest.Owner.Email, opt =>
                    opt.MapFrom(src => src.OwnerEmail))
                .ForPath(dest =>
                    dest.Owner.Firstname, opt =>
                    opt.MapFrom(src => src.OwnerFirstname))
                .ForPath(dest =>
                    dest.Owner.Lastname, opt =>
                    opt.MapFrom(src => src.OwnerLastname))
                .ReverseMap();
            CreateMap<CommentDetailDto, Comment>()
                .ForPath(dest =>
                    dest.Owner.UserName, opt =>
                    opt.MapFrom(src => src.OwnerUserName))
                .ForPath(dest =>
                    dest.Owner.Id, opt =>
                    opt.MapFrom(src => src.OwnerId))
                .ForPath(dest =>
                    dest.Owner.Email, opt =>
                    opt.MapFrom(src => src.OwnerEmail))
                .ForPath(dest =>
                    dest.Owner.Firstname, opt =>
                    opt.MapFrom(src => src.OwnerFirstname))
                .ForPath(dest =>
                    dest.Owner.Lastname, opt =>
                    opt.MapFrom(src => src.OwnerLastname))
                .ReverseMap();
            CreateMap<CommentUpdateDto, Comment>().ReverseMap();
        }
    }
}
