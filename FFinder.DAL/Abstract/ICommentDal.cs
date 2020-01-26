using FFinder.Core.DAL.Abstract;
using FFinder.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFinder.DAL.Abstract
{
    public interface ICommentDal:IEntityRepository<Comment>
    {
        string Add(Comment entity);

    }
}
