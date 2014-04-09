using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity FindById(object id);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        void Insert(TEntity entity);
        RepositoryQuery<TEntity> Query();
    }
}
