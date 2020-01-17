using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace FFinder.Entity.Concrete
{
    public class AuthIdentityUser : IdentityUser
    {
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
        public virtual ICollection<Follower> Followers { get; set; }
        public virtual  ICollection<Comment> Comments { get; set; }
        public virtual  ICollection<Post> Posts { get; set; }
        public virtual  ICollection<PostRate> PostRates { get; set; }
        public virtual  ICollection<CommentRate> CommentRates { get; set; }



    }
}