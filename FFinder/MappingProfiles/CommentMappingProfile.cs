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
                .ReverseMap();
            CreateMap<CommentDetailDto, Comment>()
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
                .ReverseMap();
            CreateMap<CommentUpdateDto, Comment>().ReverseMap();
        }
    }
}
