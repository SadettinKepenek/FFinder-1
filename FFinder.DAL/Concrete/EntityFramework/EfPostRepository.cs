using System;
using System.Linq.Expressions;
using FFinder.Core.DAL.Concrete.EntityFramework;
using FFinder.DAL.Abstract;
using FFinder.Entity.Concrete;

namespace FFinder.DAL.Concrete.EntityFramework
{
    public class EfPostRepository: EfEntityRepositoryBase<Post, SqlDbContext>,IPostRepository
    {
        public Post Get(Expression<Func<Post, bool>> filter = null)
        {
            using SqlDbContext context=new SqlDbContext();
            if (filter==null)
            {
                
            }

            return null;
        }
    }
}