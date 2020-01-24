using FFinder.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using FFinder.Core.DataTransferObjects.Comment;

namespace FFinder.Core.DataTransferObjects.CommentRate
{
    public class CommentRateDetailDto
    {
        public string CommentRateId { get; set; }
        public bool IsLike { get; set; }
        public DateTime RateDate { get; set; }
        public string CommentId { get; set; }
        public string OwnerId { get; set; }
        public bool IsActive { get; set; }
        public string OwnerUserName { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerFirstname { get; set; }
        public string OwnerLastname { get; set; }
        public string CommentBody { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentOwnerId { get; set; }
        public string CommentPostId { get; set; }

    }
}
