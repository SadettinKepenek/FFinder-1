using FFinder.Core.DataTransferObjects.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.BLL.Abstract
{
    public interface ICommentService
    {
        List<CommentListDto> GetAll();
        CommentDetailDto GetById(string id);
        void Add(CommentAddDto model);
        void Update(CommentUpdateDto model);
        void Delete(string id);
    }
}
