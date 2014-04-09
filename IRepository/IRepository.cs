using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRepository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity FindById(object id);
        IEnumerable<TEntity> SqlCommand(string command);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        void Insert(TEntity entity);
        IRepositoryQuery<TEntity> Query();
    }
}
