using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRepository
{
    public interface IUnitOfWork
    {
        void Dispose();
        void Commit();
        void Dispose(bool disposing);
        IRepository<T> Repository<T>() where T : BaseEntity;
    }
}
