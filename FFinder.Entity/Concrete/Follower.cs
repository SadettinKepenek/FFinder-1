using System;
using System.ComponentModel.DataAnnotations;

namespace FFinder.Entity.Concrete
{
    public class Follower
    {
        [Key] public string FollowerId { get; set; }
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public DateTime FriendshipDate { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsActive { get; set; }

        public virtual AuthIdentityUser User1 { get; set; }
        public virtual AuthIdentityUser User2 { get; set; }
    }
}