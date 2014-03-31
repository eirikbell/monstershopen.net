using System;
using System.Collections.Generic;
using DomainModel;

namespace DataLayer.Interfaces
{
    public interface IEntityRepository<TEntity> : IDisposable
        where TEntity : IObjectWithState
    {
        TEntity Find(int entityId);
        ICollection<TEntity> All { get; }
    }
}
