using FFinder.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using FFinder.Core.DataTransferObjects.Comment;
using FFinder.Core.DataTransferObjects.User;

namespace FFinder.Core.DataTransferObjects.CommentRate
{
    public class CommandRateListDto
    {
        public string CommentRateId { get; set; }
        public bool IsLike { get; set; }
        public DateTime RateDate { get; set; }
        public string CommentId { get; set; }
        public string OwnerId { get; set; }
        public bool IsActive { get; set; }
        public virtual UserListDto Owner { get; set; }
        public virtual CommentListDto Comment { get; set; }
    }
}
