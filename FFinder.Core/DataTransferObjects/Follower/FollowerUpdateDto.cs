using System;
using FFinder.Entity.Concrete;

namespace FFinder.Core.DataTransferObjects.Follower
{
    public class FollowerUpdateDto
    {
        public string FollowerId { get; set; }
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public DateTime FriendshipDate { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsActive { get; set; }
    }
}