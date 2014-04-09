using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace IRepository
{
    public interface IRepositoryQuery<TEntity> where TEntity : BaseEntity
    {
        IRepositoryQuery<TEntity> Filter(
            Expression<Func<TEntity, bool>> filter);

        IRepositoryQuery<TEntity> OrderBy(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        IRepositoryQuery<TEntity> Include(
            Expression<Func<TEntity, object>> expression);

        IEnumerable<TEntity> GetPage(
            int page, int pageSize, out int totalCount);

        IEnumerable<TEntity> Get();

    }
}
