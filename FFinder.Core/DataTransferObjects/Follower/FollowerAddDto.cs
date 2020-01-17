using System;
using FFinder.Entity.Concrete;

namespace FFinder.Core.DataTransferObjects.Follower
{
    public class FollowerAddDto
    {
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public DateTime FriendshipDate { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsActive { get; set; }
    }
}