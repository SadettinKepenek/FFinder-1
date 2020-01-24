using System;
using System.Collections.Generic;
using System.Text;
using FFinder.Core.DataTransferObjects.Comment;
using FFinder.Core.DataTransferObjects.CommentRate;
using FFinder.Core.DataTransferObjects.Follower;
using FFinder.Core.DataTransferObjects.Post;
using FFinder.Core.DataTransferObjects.PostRate;

namespace FFinder.Core.DataTransferObjects.User
{
    public class UserListDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public string? AboutMe { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? ViberUrl { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public string School { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<FollowerListDto> Followers { get; set; }
        public virtual ICollection<CommentListDto> Comments { get; set; }
        public virtual ICollection<PostListDto> Posts { get; set; }
        public virtual ICollection<PostRateListDto> PostRates { get; set; }
        public virtual ICollection<CommentRateListDto> CommentRates { get; set; }
    }
}
