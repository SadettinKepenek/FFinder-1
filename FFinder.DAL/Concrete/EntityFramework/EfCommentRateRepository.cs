using FFinder.Core.DAL.Concrete.EntityFramework;
using FFinder.DAL.Abstract;
using FFinder.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FFinder.DAL.Concrete.EntityFramework
{
    public class EfCommentRateRepository: EfEntityRepositoryBase<CommentRate,SqlDbContext>,ICommentRateDal
    {
        public CommentRate Get(Expression<Func<CommentRate, bool>> filter = null)
        {
            using SqlDbContext context = new SqlDbContext();
            return filter == null ? context.CommentRates.Include(x => x.Owner).Include(y => y.Comment).FirstOrDefault() :
                context.CommentRates.Include(x => x.Owner).Include(y => y.Comment).FirstOrDefault(filter);
            
        }
        public List<CommentRate> GetList(Expression<Func<CommentRate, bool>> filter = null)
        {
            using SqlDbContext context = new SqlDbContext();
            return filter == null ? context.CommentRates.Include(x => x.Owner).Include(y => y.Comment).ToList() :
                context.CommentRates.Include(x => x.Owner).Include(y => y.Comment).Where(filter).ToList();

        }
    }
}
