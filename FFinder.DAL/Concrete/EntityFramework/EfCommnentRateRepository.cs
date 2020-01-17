using FFinder.Core.DAL.Concrete.EntityFramework;
using FFinder.DAL.Abstract;
using FFinder.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FFinder.DAL.Concrete.EntityFramework
{
    class EfCommnentRateRepository: EfEntityRepositoryBase<CommentRate,SqlDbContext>,ICommentRateDal
    {
        public Comment Get(Expression<Func<CommentRate, bool>> filter = null)
        {
            using SqlDbContext context = new SqlDbContext();
            if (filter == null)
            {

            }
            return null;
        }
    }
}
