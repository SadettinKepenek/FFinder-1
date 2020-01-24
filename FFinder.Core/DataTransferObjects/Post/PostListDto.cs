using System;
using System.Collections.Generic;
using FFinder.Core.DataTransferObjects.Comment;
using FFinder.Core.DataTransferObjects.PostRate;
using FFinder.Core.DataTransferObjects.User;
using FFinder.Entity.Concrete;

namespace FFinder.Core.DataTransferObjects.Post
{
    public class PostListDto
    {
        public string PostId { get; set; }
        public string PostImageUrl { get; set; }
        public string PostBody { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }
        public string OwnerId { get; set; }
        public virtual UserListDto Owner { get; set; }
        public virtual ICollection<CommentDetailDto> Comments { get; set; }
        public virtual ICollection<PostRateListDto> Rates { get; set; }
    }
}