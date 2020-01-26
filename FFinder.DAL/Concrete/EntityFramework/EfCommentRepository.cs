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
    public class EfCommentRepository : EfEntityRepositoryBase<Comment, SqlDbContext>, ICommentDal
    {
        public Comment Get(Expression<Func<Comment, bool>> filter = null)
        {
            using SqlDbContext context = new SqlDbContext();

            return filter == null ?
           context.Comment.Include(x => x.Rates).Include(x => x.Post).ThenInclude(y => y.Owner).FirstOrDefault() :
            context.Comment.Include(x => x.Rates).Include(x => x.Post).ThenInclude(y => y.Owner).Where(filter).FirstOrDefault();

            
        }
        public List<Comment> GetList(Expression<Func<Comment, bool>> filter = null)
        {
            using SqlDbContext context = new SqlDbContext();
            return filter == null ?
                context.Comment.Include(x => x.Rates).Include(x => x.Post).ThenInclude(y => y.Owner).ToList() :
                 context.Comment.Include(x => x.Rates).Include(x => x.Post).ThenInclude(y => y.Owner).Where(filter).ToList();
        }

        public string Add(Comment entity)
        {
            using SqlDbContext context = new SqlDbContext();
            context.Add(entity);
            context.SaveChanges();
            return entity.CommentId;
        }
    }
}


