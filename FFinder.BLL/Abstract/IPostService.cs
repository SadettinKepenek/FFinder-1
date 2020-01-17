using FFinder.Core.DataTransferObjects.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.BLL.Abstract
{
    public interface IPostService
    {
        List<PostListDto> GetAll();
        PostDetailDto GetById(string id);
        void Add(PostAddDto model);
        void Update(PostUpdateDto model);
        void Delete(string id);
    }
}
