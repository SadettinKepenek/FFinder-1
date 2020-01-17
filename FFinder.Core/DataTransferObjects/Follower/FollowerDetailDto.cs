using System;
using FFinder.Core.DataTransferObjects.User;
using FFinder.Entity.Concrete;

namespace FFinder.Core.DataTransferObjects.Follower
{
    public class FollowerDetailDto
    {
        public string FollowerId { get; set; }
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public DateTime FriendshipDate { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsActive { get; set; }

        public virtual UserListDto User1 { get; set; }
        public virtual UserListDto User2 { get; set; }
    }
}