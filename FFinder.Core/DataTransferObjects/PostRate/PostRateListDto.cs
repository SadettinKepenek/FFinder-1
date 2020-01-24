using System;
using FFinder.Core.DataTransferObjects.Post;
using FFinder.Core.DataTransferObjects.User;
using FFinder.Entity.Concrete;

namespace FFinder.Core.DataTransferObjects.PostRate
{
    public class PostRateListDto
    {
        public string PostRateId { get; set; }
        public bool IsLike { get; set; }
        public DateTime RateDate { get; set; }
        public string PostId { get; set; }
        public string OwnerId { get; set; }
        public bool IsActive { get; set; }

        public string OwnerUserName { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerFirstname { get; set; }
        public string OwnerLastname { get; set; }

        public string PostImageUrl { get; set; }
        public string PostBody { get; set; }
        public DateTime PostPublishDate { get; set; }
        public string PostOwnerId { get; set; }
        public bool PostIsActive { get; set; }


    }
}