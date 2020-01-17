using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace FFinder.Entity.Concrete
{
    public class AuthIdentityUser : IdentityUser
    {
        public AuthIdentityUser()
        {
            PostRate=new HashSet<PostRate>();
            Follower=new HashSet<Follower>();
            Comment=new HashSet<Comment>();
            CommentRate=new HashSet<CommentRate>();
        }
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
        public virtual ICollection<Follower> Follower { get; set; }
        public virtual  ICollection<Comment> Comment { get; set; }
        public virtual  ICollection<Post> Post { get; set; }
        public virtual  ICollection<PostRate> PostRate { get; set; }
        public virtual  ICollection<CommentRate> CommentRate { get; set; }



    }
}