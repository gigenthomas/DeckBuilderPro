using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DeckBuilderPro.Repository.Interfaces;

namespace DeckBuilderPro.Repository
{
    public abstract class BaseDataContext : DbContext, IDbContext
    {
        public BaseDataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<BaseDataContext>(null);
        }

        public new IDbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            this.ApplyStateChanges();
            return base.SaveChanges();
        }

        public abstract void AddModelBuilderConfiguration(DbModelBuilder modelBuilder);
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            AddModelBuilderConfiguration(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
