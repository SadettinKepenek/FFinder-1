using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FFinder.Entity.Concrete
{
    public class Post
    {
        public Post()
        {
            Rates=new HashSet<PostRate>();
        }
        [Key] public string PostId { get; set; }
        public string PostImageUrl { get; set; }
        public string PostBody { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }
        public string OwnerId { get; set; }
        public virtual AuthIdentityUser Owner { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostRate> Rates { get; set; }

    }
}