using System;
using System.ComponentModel.DataAnnotations;

namespace FFinder.Entity.Concrete
{
    public class CommentRate
    {
        [Key] public string CommentRateId { get; set; }
        public bool IsLike { get; set; }
        public DateTime RateDate { get; set; }
        public string CommentId { get; set; }
        public string OwnerId { get; set; }
        public bool IsActive { get; set; }
        public virtual AuthIdentityUser Owner { get; set; }
        public virtual Comment Comment { get; set; }

    }
}