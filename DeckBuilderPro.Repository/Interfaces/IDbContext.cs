using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DeckBuilderPro.Repository.Interfaces
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : BaseEntity;
        int SaveChanges();
        DbEntityEntry Entry(object o);
        void Dispose();
    }
}
