using FFinder.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using FFinder.Core.DataTransferObjects.CommentRate;
using FFinder.Core.DataTransferObjects.Post;
using FFinder.Core.DataTransferObjects.PostRate;
using FFinder.Core.DataTransferObjects.User;

namespace FFinder.Core.DataTransferObjects.Comment
{
    public class CommentDetailDto
    {
        public string CommentId { get; set; }
        public string CommentBody { get; set; }
        public DateTime CommentDate { get; set; }
        public string OwnerId { get; set; }
        public string PostId { get; set; }
        public virtual UserListDto Owner { get; set; }
        public virtual PostListDto Post { get; set; }
        public virtual ICollection<CommentRateDetailDto> Rates { get; set; }
        public bool IsActive { get; set; }
    }
}
