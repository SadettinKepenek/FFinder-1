using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FFinder.Core.DAL.Abstract;
using FFinder.Core.DAL.Concrete.EntityFramework;
using FFinder.DAL.Abstract;
using FFinder.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FFinder.DAL.Concrete.EntityFramework
{
    public class EfPostRepository : EfEntityRepositoryBase<Post, SqlDbContext>, IPostRepository
    {



        public Post Get(Expression<Func<Post, bool>> filter)
        {
            using SqlDbContext context = new SqlDbContext();
            return filter == null ? context.Post
                        .Include(x => x.Owner)
                        .Include(y => y.Rates)
                        .ThenInclude(c => c.Owner)
                        .Include(x => x.Comments)
                        .ThenInclude(c => c.Owner)
                        .FirstOrDefault()
                    : context.Post
                        .Include(x => x.Owner)
                        .Include(y => y.Rates)
                        .ThenInclude(c => c.Owner)
                        .Include(x => x.Comments)
                        .ThenInclude(c => c.Owner).FirstOrDefault(filter)
                ;
        }

        public List<Post> GetList(Expression<Func<Post, bool>> filter)
        {
            using SqlDbContext context = new SqlDbContext();
            return filter == null ? context.Post.Include(x => x.Owner)
                    .Include(y => y.Rates)
                    .ThenInclude(c => c.Owner)
                    .Include(x => x.Comments)
                    .ThenInclude(c => c.Owner).ToList()
                :
                context.Post
                    .Include(x => x.Owner)
                    .Include(y => y.Rates)
                    .ThenInclude(c => c.Owner)
                    .Include(x => x.Comments)
                    .ThenInclude(c => c.Owner).Where(filter).ToList();
        }
    }
}