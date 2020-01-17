using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.Core.DataTransferObjects.Comment
{
    public class CommentUpdateDto
    {
        public string CommentId { get; set; }
        public string CommentBody { get; set; }
        public DateTime CommentDate { get; set; }
        public string OwnerId { get; set; }
        public string PostId { get; set; }
        public bool IsActive { get; set; }
    }
}
