using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FFinder.Core.DAL.Concrete.EntityFramework;
using FFinder.DAL.Abstract;
using FFinder.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FFinder.DAL.Concrete.EntityFramework
{
    public class EfPostRateRepository : EfEntityRepositoryBase<PostRate, SqlDbContext>, IPostRateRepository
    {
        public PostRate Get(Expression<Func<PostRate, bool>> filter = null)
        {
            using SqlDbContext context = new SqlDbContext();
            return filter == null ? context.PostRate
                .Include(x => x.Owner)
                .Include(y => y.Post)
                .ThenInclude(c => c.Owner)
                .FirstOrDefault() : context.PostRate
                .Include(x => x.Owner)
                .Include(y => y.Post)
                .ThenInclude(c => c.Owner).FirstOrDefault(filter);
        }

        public List<PostRate> GetList(Expression<Func<PostRate, bool>> filter = null)
        {
            using SqlDbContext context = new SqlDbContext();
            return filter == null ? context.PostRate
                .Include(x => x.Owner)
                .Include(y => y.Post)
                .ThenInclude(c => c.Owner)
                .ToList() : context.PostRate
                .Include(x => x.Owner)
                .Include(y => y.Post)
                .ThenInclude(c => c.Owner).Where(filter).ToList();
        }
    }
}