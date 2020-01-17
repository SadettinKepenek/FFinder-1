using System;
using FFinder.Core.DataTransferObjects.Post;
using FFinder.Core.DataTransferObjects.User;
using FFinder.Entity.Concrete;

namespace FFinder.Core.DataTransferObjects.PostRate
{
    public class PostRateDetailDto
    {
        public string PostRateId { get; set; }
        public bool IsLike { get; set; }
        public DateTime RateDate { get; set; }
        public string PostId { get; set; }
        public string OwnerId { get; set; }
        public bool IsActive { get; set; }
        public virtual UserListDto Owner { get; set; }
        public virtual PostListDto Post { get; set; }
    }
}