using System;
using System.Collections.Generic;
using DomainModel;

namespace DataLayer.Contract
{
    public interface IEntityRepository<TEntity, in TEntityKeyType> : IDisposable
        where TEntity : IObjectWithState
    {
        TEntity Find(TEntityKeyType entityId);
        ICollection<TEntity> All { get; }
    }
}
