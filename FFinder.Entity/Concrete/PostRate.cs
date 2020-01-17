using System;
using System.ComponentModel.DataAnnotations;

namespace FFinder.Entity.Concrete
{
    public class PostRate
    {
        [Key] public string PostRateId { get; set; }
        public bool IsLike { get; set; }
        public DateTime RateDate { get; set; }
        public string PostId { get; set; }
        public string OwnerId { get; set; }
        public bool IsActive { get; set; }
        public virtual AuthIdentityUser Owner { get; set; }
        public virtual Post Post { get; set; }


    }
}