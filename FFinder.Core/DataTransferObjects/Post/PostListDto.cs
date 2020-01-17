using System;
using System.Collections.Generic;
using FFinder.Entity.Concrete;

namespace FFinder.Core.DataTransferObjects.Post
{
    public class PostListDto
    {
        public string PostId { get; set; }
        public string PostImageUrl { get; set; }
        public string PostBody { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }
        public string OwnerId { get; set; }
        public virtual AuthIdentityUser Owner { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Entity.Concrete.PostRate> Rates { get; set; }
    }
}