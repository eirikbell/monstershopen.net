using System;
using System.Data.Entity.Infrastructure;
using DomainModel;

namespace DataLayer.Interfaces
{
    public interface IContext : IDisposable
    {
        int SaveChanges();
        void SetState(object entity, State state);
        void SetAdded(object entity);
        void SetModified(object entity);
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
