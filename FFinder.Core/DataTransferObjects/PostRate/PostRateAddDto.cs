using System;
using FFinder.Entity.Concrete;

namespace FFinder.Core.DataTransferObjects.PostRate
{
    public class PostRateAddDto
    {
        public bool IsLike { get; set; }
        public DateTime RateDate { get; set; }
        public string PostId { get; set; }
        public string OwnerId { get; set; }
        public bool IsActive { get; set; }
    }
}