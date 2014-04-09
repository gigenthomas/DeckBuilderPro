using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace IRepository
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : BaseEntity;
        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T:BaseEntity;
        void Dispose();
        void ApplyAuditChanges();
        IEnumerable<T> SqlCommand<T>(string cmd) where T : BaseEntity;
    }
}
