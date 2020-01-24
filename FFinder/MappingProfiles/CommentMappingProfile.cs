﻿using AutoMapper;
using FFinder.Core.DataTransferObjects.Comment;
using FFinder.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFinder.MappingProfiles
{
    public class CommentMappingProfile :Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<CommentAddDto, Comment>().ReverseMap();
            CreateMap<CommentListDto, Comment>().ReverseMap();
            CreateMap<CommentDetailDto, Comment>().ReverseMap();
            CreateMap<CommentUpdateDto, Comment>().ReverseMap();
        }
    }
}
