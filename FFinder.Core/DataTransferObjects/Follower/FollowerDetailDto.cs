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

        public string User1UserName { get; set; }
        public string User1Email { get; set; }
        public string User1Firstname { get; set; }
        public string User1Lastname { get; set; }
        public string User1ProfilePhoto { get; set; }


        public string User2UserName { get; set; }
        public string User2Email { get; set; }
        public string User2Firstname { get; set; }
        public string User2Lastname { get; set; }
        public string User2ProfilePhoto { get; set; }

    }
}