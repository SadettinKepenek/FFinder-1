using System.Collections.Generic;
using FFinder.Core.DataTransferObjects.PostRate;

namespace FFinder.BLL.Abstract
{
    public interface IPostRateService
    {
        List<PostRateListDto> Get();
        PostRateDetailDto Get(string id);
        void Add(PostRateAddDto dto);
        void Update(PostRateUpdateDto dto);
        void Delete(string id);
    }
}