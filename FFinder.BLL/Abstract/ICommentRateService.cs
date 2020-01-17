using FFinder.Core.DataTransferObjects.CommentRate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.BLL.Abstract
{
    public interface ICommentRateService
    {
        List<CommentRateListDto> GetAll();
        CommentRateDetailDto GetById(string id);
        void Add(CommentRateAddDto model);
        void Update(CommentRateUpdateDto model);
        void Delete(string id);
    }
}
