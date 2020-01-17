using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FFinder.Core.DAL.Abstract
{

    public interface IEntityRepository<T> where T : class, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        bool IsExists(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void AddRange(List<T> entities);
    }

}