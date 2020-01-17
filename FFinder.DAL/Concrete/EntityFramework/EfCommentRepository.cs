using FFinder.Core.DAL.Concrete.EntityFramework;
using FFinder.DAL.Abstract;
using FFinder.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FFinder.DAL.Concrete.EntityFramework
{
    public class EfCommentRepository : EfEntityRepositoryBase<Comment, SqlDbContext>, ICommentDal
    {
        public Comment Get(Expression<Func<Comment, bool>> filter = null)
        {
            using SqlDbContext context = new SqlDbContext();
            if (filter == null)
            {

            }
            return null;
        }
    }
}
