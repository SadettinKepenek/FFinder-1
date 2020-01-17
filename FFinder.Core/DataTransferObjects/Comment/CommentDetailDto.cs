using FFinder.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.Core.DataTransferObjects.Comment
{
    public class CommentDetailDto
    {
        public string CommentId { get; set; }
        public string CommentBody { get; set; }
        public DateTime CommentDate { get; set; }
        public string OwnerId { get; set; }
        public string PostId { get; set; }
        public virtual AuthIdentityUser Owner { get; set; }
        public virtual Entity.Concrete.Post Post { get; set; }
        public virtual ICollection<Entity.Concrete.PostRate> Rates { get; set; }
        public bool IsActive { get; set; }
    }
}
