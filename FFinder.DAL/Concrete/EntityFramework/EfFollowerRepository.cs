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
    public class EfFollowerRepository : EfEntityRepositoryBase<Follower, SqlDbContext>, IFollowerRepository
    {
        public Follower Get(Expression<Func<Follower, bool>> filter = null)
        {
            using SqlDbContext sqlDbContext = new SqlDbContext();

            return filter == null
                ? sqlDbContext.Followers.Include(x => x.User1)
                    .Include(y => y.User2).FirstOrDefault()
                : sqlDbContext.Followers.Include(x => x.User1)
                    .Include(y => y.User2).FirstOrDefault(filter);
        }

        public List<Follower> GetList(Expression<Func<Follower, bool>> filter = null)
        {
            using SqlDbContext sqlDbContext = new SqlDbContext();
            return filter == null
                ? sqlDbContext.Followers.Include(x => x.User1)
                    .Include(y => y.User2).ToList()
                : sqlDbContext.Followers.Include(x => x.User1)
                    .Include(y => y.User2).Where(filter).ToList();
        }
    }
}