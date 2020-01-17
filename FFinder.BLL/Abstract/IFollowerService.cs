using System.Collections.Generic;
using FFinder.Core.DataTransferObjects.Follower;

namespace FFinder.BLL.Abstract
{
    public interface IFollowerService
    {
        List<FollowerListDto> Get();
        FollowerDetailDto Get(string id);
        void Add(FollowerAddDto dto);
        void Update(FollowerUpdateDto dto);
        void Delete(string id);
    }
}